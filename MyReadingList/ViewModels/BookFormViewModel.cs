﻿using MyReadingList.Models;
using System;
using System.Collections.Generic;

namespace MyReadingList.ViewModels
{
    public class BookFormViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Pages { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Reader { get; set; }
        public IEnumerable<Reader> Readers { get; set; }

        public int Level { get; set; }
        public IEnumerable<Level> Levels { get; set; }

        public int Rating { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }


        public string Comments { get; set; }
        public object Books { get; internal set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (Id!= 0)? "Update" : "Create";
            }
        }
        public DateTime GetDateTime()

        {
             return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        }


    }





