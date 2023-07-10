import numpy as np
import csv
import pandas as pd
import pyodbc

# remove BOM junk data from excel exported file
# this could probabbly also be done inline.
s = open("C:\Python\Data\ABS_C16_T01_TS_SA_08062021164508583.xls", mode='r', encoding='utf-8-sig').read()
open("C:\Python\Data\ABS_C16_T01_TS_SA_08062021164508583.csv", mode='w', encoding='utf-8').write(s)

with open("C:\Python\Data\ABS_C16_T01_TS_SA_08062021164508583.csv", 'r') as x:
    sample_data = list(csv.reader(x, delimiter=","))

# get column names
columns = sample_data[0]

# get data
sample_data = sample_data[1:]

# create DataFrame from data
df = pd.DataFrame(data=sample_data, columns=columns)

convert_dict = {'SEX_ABS': int,
                'Sex': str,
                'AGE': str,
                'STATE': int,
                'State': str,
                'REGIONTYPE': str,
                'Geography Level': str,
                'ASGS_2016': str,
                'Region': str,
                'TIME': int,
                'Census year': int,
                'Value': int
                }

# convert to native data type wherever possible. strings are objects.
dfn =  df.astype(convert_dict)

# this should do it automatically according to the documentation, but it isn't working.
# dfn = df.convert_dtypes()

# get set of all regions in new data
# sets are used because the values are unique
# the map is to ensure that the datatypes of both sets are exactly the same - not wrapped in another datatype.
data_regions_new = set(map(str, dfn.loc[:,"Region"]))

# convert DataFrame to list of dictionaries
dict_records = dfn.to_dict(orient='records')

# DB tasks

cnxn = pyodbc.connect('DRIVER={Devart ODBC Driver for SQL Server};Data Source=DESKTOP-5VQLKUC;Initial Catalog=abs_stats;User ID=stats;Password=MyNewStrongPwd1@')
cursor = cnxn.cursor()

# get all regions in db as set
cursor.execute("SELECT name FROM regions") 
regions_db_set = set([row.name for row in cursor.fetchall()])

# ensure that set values are strings and not wrapped in some unexpected datatype
regions_db_set = set(map(str, regions_db_set))

# intersect with new region data to find regions not currently in db.
regions_new_set = data_regions_new.difference(regions_db_set)

# insert any new regions into db
if (len(regions_new_set) > 0):
    for region in regions_new_set:
        cursor.execute('{}{}{}'.format("INSERT INTO regions(name) VALUES ('", region, "');"))

cnxn.commit()

# get all regions as dictionary, with name as key to allow linking fks.
dict_regions = {}

result = cursor.execute("SELECT * FROM regions") 

for row in result.fetchall():
    dict_regions[row.name] = row.id

# get dictionary of sexes, with name as key to allow linking fks
dict_sexes = {}

result = cursor.execute("SELECT * FROM Sexes") 

for row in result.fetchall():
    dict_sexes[row.name] = row.id

# get dictionary of states, with name as key to allow linking fks
dict_states = {}

result = cursor.execute("SELECT * FROM States") 

for row in result.fetchall():
    dict_states[row.name] = row.id

# replace sex, region, state in new data dictionary with corresponding fk in relational tables
for data in dict_records:
    data['Sex'] = dict_sexes[data['Sex']]
    data['Region'] = dict_regions[data['Region']]
    data['State'] = dict_states[data['State']]

insert_string_template = "INSERT INTO AbsData (Sexid, AgeCode, Age, Stateid, RegionType, GeographyLevel, ASGS_2016, Regionid, Time, CensusYear, Value) VALUES ("

for row in dict_records:
    insert_string = "{}{},'{}','{}',{},'{}','{}',{},{},{},{},{}{}".format(insert_string_template, row["Sex"], row["AGE"], row["Age"], row["State"], 
        row["REGIONTYPE"], row["Geography Level"], row["ASGS_2016"], row["Region"], row["TIME"], row["Census year"], row["Value"], ");")
    cursor.execute(insert_string) 

cnxn.commit()
