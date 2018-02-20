using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldData.Models;


namespace WorldData
{
    public class City
    {
        private int _cityID;
        private string _cityName;
        private string _countryCode;
        private string _district;
        private int _population;
        private static string _sortCondition;

        public City (int id, string name, string code, string district, int population)
        {
            _cityID = id;
            _cityName = name;
            _countryCode = code;
            _district = district;
            _population = population;
        }

        public string GetCityName()
        {
            return _cityName;
        }

        public string GetCityCountryCode()
        {
            return _countryCode;
        }

        public string GetCityDistrict()
        {
            return _district;
        }

        public int GetCityPopulation()
        {
            return _population;
        }



        public static List<City> GetAll()
        {
            List<City> allCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string name = rdr.GetString(1);
              string code = rdr.GetString(2);
              string district = rdr.GetString(3);
              int population = rdr.GetInt32(4);
              City newCity = new City(cityId, name, code, district, population);
              allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
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
                _sortCondition = "CountryCode ASC";
            }
            else if (condition == "4")
            {
                _sortCondition = "CountryCode DESC";
            }
            else if (condition == "5")
            {
                _sortCondition = "District ASC";
            }
            else if (condition == "6")
            {
                _sortCondition = "District DESC";
            }
            else if (condition == "7")
            {
                _sortCondition = "Population ASC";
            }
            else if (condition == "8")
            {
                _sortCondition = "Population DESC";
            }
        }

        public static List<City> Find(string inputCode)
        {
            List<City> findCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city WHERE CountryCode = '" + inputCode + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string name = rdr.GetString(1);
              string code = rdr.GetString(2);
              string district = rdr.GetString(3);
              int population = rdr.GetInt32(4);
              City newCity = new City(cityId, name, code, district, population);
              findCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return findCities;
        }

        public static List<City> Sort()
        {
            List<City> sortCities = new List<City> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city ORDER BY " + _sortCondition + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int cityId = rdr.GetInt32(0);
              string name = rdr.GetString(1);
              string code = rdr.GetString(2);
              string district = rdr.GetString(3);
              int population = rdr.GetInt32(4);
              City newCity = new City(cityId, name, code, district, population);
              sortCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return sortCities;
        }
    }
}
