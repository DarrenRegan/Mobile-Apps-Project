﻿using System;
using System.Collections.Generic;
using System.Text;

namespace myApp.Models
{
    class Weather
    {
        //Model for xaml code to bind to these values
        public string Title { get; set; } = " ";
        public string Temperature { get; set; } = " ";
        public string Wind { get; set; } = " ";
        public string Humidity { get; set; } = " ";
        public string Visibility { get; set; } = " ";
        public string Sunrise { get; set; } = " ";
        public string Sunset { get; set; } = " ";
    }
}
