﻿namespace RetailApi.Models
{
    public class State
    {
        public int ID { get; set; }

        public string STATE_NAME { get; set; }

        public int COUNTRY_ID { get; set; }

        public String COUNTRY_NAME { get; set; }

        public string IS_DELETED { get; set; }
    }
    public class StateResponse
    {
        public string flag { get; set; }
        public string message { get; set; }
        public State data { get; set; }
    }
}
