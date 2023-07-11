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

# Age ids are numeric, except for "All ages", which has a string code 'TT'. To make id column consistent, replace it with numeric value. Since 0 is already taken, use -1
df.loc[df["AGE"] == "TT", "AGE"] = -1

convert_dict = {'SEX_ABS': int,
                'Sex': str,
                'AGE': int,
                'STATE': int,
                'ASGS_2016': int,
                'TIME': int,
                'Census year': int,
                'Value': int
                }

# convert to native data type wherever possible. strings are objects.
dfn =  df.astype(convert_dict)

# this should do it automatically according to the documentation, but it isn't working.
# dfn = df.convert_dtypes()

# get set of all regions by code in new data
# sets are used because the values are unique
# the map is to ensure that the datatypes of both sets are exactly the same - not wrapped in another datatype.
data_regions_new = set(map(int, dfn.loc[:,"ASGS_2016"]))
data_sexes_new = set(map(int, dfn.loc[:,"SEX_ABS"]))
data_ages_new = set(map(int, dfn.loc[:,"AGE"]))

# convert DataFrame to list of dictionaries
dict_records_list = dfn.to_dict(orient='records')

#AGE

# create look-up list for ages by AGE id

dict_ages = {}
set_ages = set()

for d in dict_records_list:
    if d['AGE'] not in set_ages:
        # used to exclude duplicates
        set_ages.add(d['AGE'])
        dict_ages[d['AGE']] = d['Age']


# REGION

# create look-up list for regions by ASGS_2016 id
dict_regions = {}
set_regions = set()

for d in dict_records_list:
    if d['ASGS_2016'] not in set_regions:
        # used to exclude duplicates
        set_regions.add(d['ASGS_2016'])
        dict_regions[d['ASGS_2016']] = d['Region']

# SEX

# create look-up list of sexes by SEX_ABS id

dict_sexes = {}
set_sexes = set()

for d in dict_records_list:
    if d['SEX_ABS'] not in set_sexes:
        # used to exclude duplicates
        set_sexes.add(d['SEX_ABS'])
        dict_sexes[d['SEX_ABS']] = d['Sex']

#STATE

# create look-up list of states by STATE id

dict_states = {}
set_states = set()

for d in dict_records_list:
    if d['STATE'] not in set_states:
        # used to exclude duplicates
        set_states.add(d['STATE'])
        dict_states[d['STATE']] = d['State']

# DB TASKS

cnxn = pyodbc.connect('DRIVER={Devart ODBC Driver for SQL Server};Data Source=DESKTOP-5VQLKUC;Initial Catalog=ABSPopulationData;User ID=stats;Password=MyNewStrongPwd1@')
cursor = cnxn.cursor()

# Since state table won't change, just check if it has been populated.
cursor.execute("SELECT ABSStateId FROM DimState") 
states_db_set = set([row.ABSStateId for row in cursor.fetchall()])

if len(states_db_set) == 0:
     for state in set_states:
        id = state
        # get state name from look-up list
        name = dict_states[state]
        insert_string = "{}'{}',{}{}".format("INSERT INTO DimState(name, ABSStateId) VALUES (", name, id,");")
        cursor.execute(insert_string)

cnxn.commit()

# update ages table with any new ages in dataset
cursor.execute("SELECT ABSAgeId FROM DimAge") 
ages_db_set = set([row.ABSAgeId for row in cursor.fetchall()])

ages_db_set = set(map(int, ages_db_set))
# intersect with new region ids to find regions not currently in db.
ages_new_set = data_ages_new.difference(ages_db_set)

# intersect with new region ids to find regions not currently in db.
ages_new_set = data_ages_new.difference(ages_db_set)

# insert any new regions into db
if (len(ages_new_set) > 0):    
    for age in ages_new_set:
        id = age
        # get region name from look-up list
        name = dict_ages[age]
        insert_string = "{}'{}',{}{}".format("INSERT INTO DimAge(name, ABSAgeId) VALUES (", name, id,");")
        cursor.execute(insert_string)

cnxn.commit()

# update regions table with any new regions in data set
# get all region ids in db as set
cursor.execute("SELECT ABSRegionId FROM DimRegion") 
regions_db_set = set([row.ABSRegionId for row in cursor.fetchall()])

# ensure that set values are ints and not wrapped in some unexpected datatype
regions_db_set = set(map(int, regions_db_set))

# intersect with new region ids to find regions not currently in db.
regions_new_set = data_regions_new.difference(regions_db_set)

# insert any new regions into db
if (len(regions_new_set) > 0):    
    for region in regions_new_set:
        id = region
        # get region name from look-up list
        name = dict_regions[region]
        insert_string = "{}'{}',{}{}".format("INSERT INTO DimRegion(name, ABSRegionId) VALUES (", name, id,");")
        cursor.execute(insert_string)

cnxn.commit()

# update sexes table with any new sexes in data set

cursor.execute("SELECT ABSSexId FROM DimSex") 
sexes_db_set = set([row.ABSSexId for row in cursor.fetchall()])

sexes_db_set = set(map(int, sexes_db_set))
sexes_new_set = data_sexes_new.difference(sexes_db_set)

if (len(sexes_new_set) > 0):    
    for sex in sexes_new_set:
        id = sex
        # get sex name from look-up list
        name = dict_sexes[sex]
        insert_string = "{}'{}',{}{}".format("INSERT INTO DimSex(name, ABSSexId) VALUES (", name, id,");")
        cursor.execute(insert_string)

cnxn.commit()

# get all regions as dictionary, with name as key to allow linking fks.
dict_regions = {}

result = cursor.execute("SELECT * FROM DimRegion") 

for row in result.fetchall():
    dict_regions[row.name] = row.id

# get dictionary of sexes, with name as key to allow linking fks
dict_sexes = {}

result = cursor.execute("SELECT * FROM DimSex") 

for row in result.fetchall():
    dict_sexes[row.name] = row.id

# get dictionary of states, with name as key to allow linking fks
dict_states = {}

result = cursor.execute("SELECT * FROM DimState") 

for row in result.fetchall():
    dict_states[row.name] = row.id

# get dictionary of ages, with name as key to allow linking fks
dict_ages = {}

result = cursor.execute("SELECT * FROM DimAge") 

for row in result.fetchall():
    dict_ages[row.name] = row.id


# replace sex, region, state in new data dictionary with corresponding fk in relational tables
for data in dict_records_list:
    data['Sex'] = dict_sexes[data['Sex']]
    data['Region'] = dict_regions[data['Region']]
    data['State'] = dict_states[data['State']]
    data['Age'] = dict_ages[data['Age']]

insert_string_template = "INSERT INTO FactPopulation(Sexid, AgeCodeid, Stateid, RegionType, GeographyLevel, Regionid, Time, CensusYear, Value) VALUES ("

for row in dict_records_list:
    insert_string = "{}{},{},{},'{}','{}','{}',{},{},{}{}".format(insert_string_template, row["Sex"], row["Age"], row["State"], 
        row["REGIONTYPE"], row["Geography Level"], row["Region"], row["TIME"], row["Census year"], row["Value"], ");")
    print(insert_string)
    cursor.execute(insert_string) 

cnxn.commit()
