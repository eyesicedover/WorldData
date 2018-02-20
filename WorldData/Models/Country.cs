using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData
{
    public class Country
    {
        private string _countryCode;
        private string _countryName;
        private string _continent;
        private string _region;
        private int _countryPopulation;
        private static string _sortCondition;

        public Country (string code, string name, string continent, string region, int population)
        {
            _countryCode = code;
            _countryName = name;
            _continent = continent;
            _region = region;
            _countryPopulation = population;
        }

        public string GetCountryCode()
        {
            return _countryCode;
        }

        public string GetCountryName()
        {
            return _countryName;
        }

        public string GetCountryContinent()
        {
            return _continent;
        }

        public string GetCountryRegion()
        {
            return _region;
        }

        public int GetCountryPopulation()
        {
            return _countryPopulation;
        }

        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              string countryCode = rdr.GetString(0);
              string name = rdr.GetString(1);
              string continent = rdr.GetString(2);
              string region = rdr.GetString(3);
              int population = rdr.GetInt32(6);
              Country newCountry = new Country(countryCode, name, continent, region, population);
              allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static void SetSortCondition(string condition)
        {
            if (condition == "1")
            {
                _sortCondition = "Name ASC";
            }
            else if (condition == "2")
            {
                _sortCondition = "Name DESC";
            }
            else if (condition == "3")
            {
                _sortCondition = "Code ASC";
            }
            else if (condition == "4")
            {
                _sortCondition = "Code DESC";
            }
            else if (condition == "5")
            {
                _sortCondition = "Continent ASC";
            }
            else if (condition == "6")
            {
                _sortCondition = "Continent DESC";
            }
            else if (condition == "7")
            {
                _sortCondition = "Region ASC";
            }
            else if (condition == "8")
            {
                _sortCondition = "Region DESC";
            }
            else if (condition == "9")
            {
                _sortCondition = "Population ASC";
            }
            else if (condition == "10")
            {
                _sortCondition = "Population DESC";
            }
        }

        public static List<Country> Sort()
        {
            List<Country> sortCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country ORDER BY " + _sortCondition + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              string countryCode = rdr.GetString(0);
              string name = rdr.GetString(1);
              string continent = rdr.GetString(2);
              string region = rdr.GetString(3);
              int population = rdr.GetInt32(6);
              Country newCountry = new Country(countryCode, name, continent, region, population);
              sortCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return sortCountries;
        }
    }
}
