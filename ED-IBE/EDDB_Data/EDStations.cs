﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using IBE.EDDB_Data.CommoditiesJsonTypes;
using IBE.Enums_and_Utility_Classes;
using System.Diagnostics;

namespace IBE.EDDB_Data
{

    public class EDStation
    {
        private Int32 currentIndex;
        private Boolean m_ListingExtendMode;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("system_id")]
        public int SystemId { get; set; }

        // only temporary needed if we don't know the system-id
        public String SystemName { get; set; }

        [JsonProperty("max_landing_pad_size")]
        public string MaxLandingPadSize { get; set; }

        [JsonProperty("distance_to_star")]
        public int? DistanceToStar { get; set; }

        [JsonProperty("faction")]
        public string Faction { get; set; }

        [JsonProperty("government")]
        public string Government { get; set; }

        [JsonProperty("allegiance")]
        public string Allegiance { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("has_blackmarket")]
        public bool HasBlackmarket { get; set; }

        [JsonProperty("has_market")]
        public bool HasMarket { get; set; }

        [JsonProperty("has_refuel")]
        public bool HasRefuel { get; set; }

        [JsonProperty("has_repair")]
        public bool HasRepair { get; set; }

        [JsonProperty("has_rearm")]
        public bool HasRearm { get; set; }

        [JsonProperty("has_outfitting")]
        public bool HasOutfitting { get; set; }

        [JsonProperty("has_shipyard")]
        public bool HasShipyard { get; set; }

        [JsonProperty("import_commodities")]
        public string[] ImportCommodities { get; set; }

        [JsonProperty("export_commodities")]
        public string[] ExportCommodities { get; set; }

        [JsonProperty("prohibited_commodities")]
        public string[] ProhibitedCommodities { get; set; }

        [JsonProperty("economies")]
        public string[] Economies { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("listings")]
        public Listing[] Listings { get; set; }

        // v4 / v4.1

        [JsonProperty("shipyard_updated_at")]
        public int? Shipyard_UpdatedAt { get; set; }

        [JsonProperty("outfitting_updated_at")]
        public int? Outfitting_UpdatedAt { get; set; }

        [JsonProperty("market_updated_at")]
        public int? Market_UpdatedAt { get; set; }

        [JsonProperty("type_id")]
        public int? TypeID { get; set; }

        [JsonProperty("has_commodities")]
        public bool HasCommodities { get; set; }

        [JsonProperty("is_planetary")]
        public bool IsPlanetary { get; set; }

        [JsonProperty("selling_ships")]
        public string[] SellingShips { get; set; }

        [JsonProperty("selling_modules")]
        public int[] SellingModules { get; set; }

         /// <summary>
         /// creates a new station 
         /// </summary>
        public EDStation()
        {
            clear();
        }

        /// <summary>
         /// creates a new station as a copy of another station
         /// only Id and StationID must declared extra
         /// </summary>
         /// <param name="newId"></param>
         /// <param name="sourceSystemID"></param>
         /// <param name="sourceStation"></param>
        public EDStation(int newId, int sourceSystemID, EDStation sourceStation)
        {
            clear();

            Id              = newId;
            SystemId        = sourceSystemID;
            getValues(sourceStation);   
        }

        /// <summary>
        /// creates a new station with values from the CsvRow object
        /// </summary>
        /// <param name="currentRow"></param>
        public EDStation(CsvRow Csv_Row)
        {
            try
            {
                var SystemsAndStations =  Program.Data.BaseData.visystemsandstations;

                Id                    = 0;
                SystemId              = 0;

                var stationID = (SQL.Datasets.dsEliteDB.visystemsandstationsRow[])SystemsAndStations.Select(
                                        String.Format("systemname = '{0}' and stationname = '{1}'",  
                                        SQL.DBConnector.DTEscape(Csv_Row.SystemName), 
                                        SQL.DBConnector.DTEscape(Csv_Row.StationName)));
                             
                if(stationID.GetUpperBound(0) >= 0)
                {
                    Id                    = stationID[0].StationID;
                    SystemId              = stationID[0].SystemID;
                }
                else
                {
                    // we'll get the system-id later
                    SystemName            = Csv_Row.SystemName;
                }

                Name                  = Csv_Row.StationName;
                MaxLandingPadSize     = null;
                DistanceToStar        = null;
                Faction               = null;
                Government            = null;
                Allegiance            = null;
                State                 = null;
                Type                  = null;
                HasBlackmarket        = false;
                HasMarket             = false;
                HasRefuel             = false;
                HasRepair             = false;
                HasRearm              = false;
                HasOutfitting         = false;
                HasShipyard           = false;

                ImportCommodities     = new String[0];
                ExportCommodities     = new String[0];
                ProhibitedCommodities = new String[0];
                Economies             = new String[0];

                Listings              = new Listing[0];
                    
                UpdatedAt             = 0; 
                Shipyard_UpdatedAt    = 0;
                Outfitting_UpdatedAt  = 0;
                Market_UpdatedAt      = 0;
                TypeID                = null;
                HasCommodities        = false; 
                IsPlanetary           = false;
                SellingShips          = new String[0];
                SellingModules        = new Int32[0];


            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating new EDStation object with values from CsvRow object", ex);
            }
        }

        /// <summary>
        /// creates a new station with values from the CsvRow object
        /// </summary>
        /// <param name="currentRow"></param>
        public EDStation(Listing listingString)
        {
            try
            {
                var SystemsAndStations =  Program.Data.BaseData.visystemsandstations;

                Id                    = 0;
                SystemId              = 0;

                var stationID = (SQL.Datasets.dsEliteDB.visystemsandstationsRow[])SystemsAndStations.Select(
                                        String.Format("stationid = '{0}'",  
                                        listingString.StationId));
                             
                if(stationID.GetUpperBound(0) >= 0)
                {
                    Id                    = stationID[0].StationID;
                    SystemId              = stationID[0].SystemID;
                }
                else
                {
                    throw new Exception("unknown station id");
                }

                Name                  = stationID[0].StationName;
                SystemName            = stationID[0].SystemName;  
                MaxLandingPadSize     = null;
                DistanceToStar        = null;
                Faction               = null;
                Government            = null;
                Allegiance            = null;
                State                 = null;
                Type                  = null;
                HasBlackmarket        = false;
                HasMarket             = false;
                HasRefuel             = false;
                HasRepair             = false;
                HasRearm              = false;
                HasOutfitting         = false;
                HasShipyard           = false;

                ImportCommodities     = new String[0];
                ExportCommodities     = new String[0];
                ProhibitedCommodities = new String[0];
                Economies             = new String[0];

                Listings              = new Listing[0];
                    
                UpdatedAt             = 0; 
                Shipyard_UpdatedAt    = 0;
                Outfitting_UpdatedAt  = 0;
                Market_UpdatedAt      = 0;
                TypeID                = null;
                HasCommodities        = false; 
                IsPlanetary           = false;
                SellingShips          = new String[0];
                SellingModules        = new Int32[0];


            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating new EDStation object with values from CsvRow object", ex);
            }
        }

        public void clear()
        {
            Id                    = 0;
            SystemId              = 0;
            Name                  = string.Empty;
            MaxLandingPadSize     = null;
            DistanceToStar        = null;
            Faction               = null;
            Government            = null;
            Allegiance            = null;
            State                 = null;
            Type                  = null;
            HasBlackmarket        = false;
            HasMarket             = false;
            HasRefuel             = false;
            HasRepair             = false;
            HasRearm              = false;
            HasOutfitting         = false;
            HasShipyard           = false;

            ImportCommodities     = new String[0];
            ExportCommodities     = new String[0];
            ProhibitedCommodities = new String[0];
            Economies             = new String[0];

            Listings              = new Listing[0];

            UpdatedAt             = 0; //new System.DateTimeOffset(##).ToUnixTimeSeconds();
            Shipyard_UpdatedAt    = 0;
            Outfitting_UpdatedAt  = 0;
            Market_UpdatedAt      = 0;
            TypeID                = null;
            HasCommodities        = false; 
            IsPlanetary           = false;
            SellingShips          = new String[0];
            SellingModules        = new Int32[0];

            ListingExtendMode     = false;
        }

        /// <summary>
        /// true, if all data *except the two IDs* is equal (case insensitive)
        /// </summary>
        /// <param name="eqSystem"></param>
        /// <returns></returns>
        public bool EqualsED(EDStation eqStation)
        {
            bool retValue = false;

            if(eqStation != null)
            {


                if (ObjectCompare.EqualsNullable(this.Name, eqStation.Name) &&
                    ObjectCompare.EqualsNullable(this.MaxLandingPadSize, eqStation.MaxLandingPadSize) && 
                    ObjectCompare.EqualsNullable(this.DistanceToStar, eqStation.DistanceToStar) && 
                    ObjectCompare.EqualsNullable(this.Faction, eqStation.Faction) && 
                    ObjectCompare.EqualsNullable(this.Government, eqStation.Government) && 
                    ObjectCompare.EqualsNullable(this.Allegiance, eqStation.Allegiance) && 
                    ObjectCompare.EqualsNullable(this.State, eqStation.State) && 
                    ObjectCompare.EqualsNullable(this.Type, eqStation.Type) && 
                    ObjectCompare.EqualsNullable(this.HasBlackmarket, eqStation.HasBlackmarket) && 
                    ObjectCompare.EqualsNullable(this.HasMarket, eqStation.HasMarket) && 
                    ObjectCompare.EqualsNullable(this.HasRefuel, eqStation.HasRefuel) &&
                    ObjectCompare.EqualsNullable(this.HasRepair, eqStation.HasRepair) && 
                    ObjectCompare.EqualsNullable(this.HasRearm, eqStation.HasRearm) &&
                    ObjectCompare.EqualsNullable(this.HasOutfitting, eqStation.HasOutfitting) &&
                    ObjectCompare.EqualsNullable(this.HasShipyard, eqStation.HasShipyard) &&
                    ObjectCompare.EqualsNullable(this.ImportCommodities, eqStation.ImportCommodities) &&
                    ObjectCompare.EqualsNullable(this.ExportCommodities, eqStation.ExportCommodities) &&
                    ObjectCompare.EqualsNullable(this.ProhibitedCommodities, eqStation.ProhibitedCommodities) &&
                    ObjectCompare.EqualsNullable(this.Economies, eqStation.Economies) &&
                    ObjectCompare.EqualsNullable(this.UpdatedAt, eqStation.UpdatedAt) &&             
                    ObjectCompare.EqualsNullable(this.Shipyard_UpdatedAt, eqStation.Shipyard_UpdatedAt) &&
                    ObjectCompare.EqualsNullable(this.Outfitting_UpdatedAt, eqStation.Outfitting_UpdatedAt) &&  
                    ObjectCompare.EqualsNullable(this.Market_UpdatedAt, eqStation.Market_UpdatedAt) &&      
                    ObjectCompare.EqualsNullable(this.TypeID, eqStation.TypeID) &&                
                    ObjectCompare.EqualsNullable(this.HasCommodities, eqStation.HasCommodities) &&        
                    ObjectCompare.EqualsNullable(this.IsPlanetary, eqStation.IsPlanetary) &&           
                    ObjectCompare.EqualsNullable(this.SellingShips, eqStation.SellingShips) &&          
                    ObjectCompare.EqualsNullable(this.SellingModules, eqStation.SellingModules)        
                    )
                        retValue = true;

            }

            return retValue;             
        }

        /// <summary>
        /// copy the values from another station exept for the ID
        /// </summary>
        /// <param name="ValueStation"></param>
        public void getValues(EDStation ValueStation, bool getAll = false)
        {
            if (getAll)
            {
                Id          = ValueStation.Id;
                SystemId    = ValueStation.SystemId;
            }

            Name                  = ValueStation.Name;
            MaxLandingPadSize     = ValueStation.MaxLandingPadSize;
            DistanceToStar        = ValueStation.DistanceToStar;
            Faction               = ValueStation.Faction;
            Government            = ValueStation.Government;
            Allegiance            = ValueStation.Allegiance;
            State                 = ValueStation.State;
            Type                  = ValueStation.Type;
            HasBlackmarket        = ValueStation.HasBlackmarket;
            HasMarket             = ValueStation.HasMarket;
            HasRefuel             = ValueStation.HasRefuel;
            HasRepair             = ValueStation.HasRepair;
            HasRearm              = ValueStation.HasRearm;
            HasOutfitting         = ValueStation.HasOutfitting;
            HasShipyard           = ValueStation.HasShipyard;

            ImportCommodities     = ValueStation.ImportCommodities.CloneN();
            ExportCommodities     = ValueStation.ExportCommodities.CloneN();
            ProhibitedCommodities = ValueStation.ProhibitedCommodities.CloneN();
            Economies             = ValueStation.Economies.CloneN();

            UpdatedAt             = ValueStation.UpdatedAt;             
            Shipyard_UpdatedAt    = ValueStation.Shipyard_UpdatedAt;    
            Outfitting_UpdatedAt  = ValueStation.Outfitting_UpdatedAt;  
            Market_UpdatedAt      = ValueStation.Market_UpdatedAt;      
            TypeID                = ValueStation.TypeID;                
            HasCommodities        = ValueStation.HasCommodities;        
            IsPlanetary           = ValueStation.IsPlanetary;           
            SellingShips          = ValueStation.SellingShips.CloneN();          
            SellingModules        = ValueStation.SellingModules.CloneN();        

        }

        /// <summary>
        /// adds a record to the pricelistings of this station
        /// </summary>
        /// <param name="CSV_String"></param>
        public void addListing(CsvRow Csv_Row, ref Dictionary<string,Int32> foundCommodityCache)
        {
            SQL.Datasets.dsEliteDB.tbcommoditylocalizationRow[] CommodityRow;
            Int32 CommodityID = 0;
            Boolean known = false;

            try
            {
                if(foundCommodityCache != null)
                {
                    if (!foundCommodityCache.TryGetValue(Csv_Row.CommodityName, out CommodityID)) 
                    {
                        CommodityRow = (SQL.Datasets.dsEliteDB.tbcommoditylocalizationRow[])Program.Data.BaseData.tbcommoditylocalization.Select(
                                            String.Format("locname = '{0}'", SQL.DBConnector.DTEscape(Csv_Row.CommodityName)));

                        if(CommodityRow.GetUpperBound(0) >= 0)
                        { 
                            CommodityID = (Int32)CommodityRow[0].commodity_id;

                            foundCommodityCache.Add(Csv_Row.CommodityName, CommodityID);

                            known = true;
                        }
                    }
                    else
                        known = true;
                }
                else
                { 
                    CommodityRow = (SQL.Datasets.dsEliteDB.tbcommoditylocalizationRow[])Program.Data.BaseData.tbcommoditylocalization.Select(
                                        String.Format("locname = '{0}'", SQL.DBConnector.DTEscape(Csv_Row.CommodityName)));

                    if(CommodityRow.GetUpperBound(0) >= 0)
                    { 
                        CommodityID = (Int32)CommodityRow[0].commodity_id;
                        known = true;
                    }

                }
                
                if(known)
                { 
                    ListingExtendMode       = true;
                    Listing newListing      = new Listing();

                    newListing.StationId    = this.Id;
                    newListing.CommodityId  = CommodityID;
                    newListing.Supply       = (Int32)Csv_Row.Supply;
                    newListing.SupplyLevel  = Csv_Row.SupplyLevel.Trim() == "" ? null : Csv_Row.SupplyLevel;
                    newListing.BuyPrice     = (Int32)Csv_Row.BuyPrice;
                    newListing.SellPrice    = (Int32)Csv_Row.SellPrice;
                    newListing.Demand       = (Int32)Csv_Row.Demand;
                    newListing.DemandLevel  = Csv_Row.DemandLevel.Trim() == "" ? null : Csv_Row.DemandLevel;
                    newListing.CollectedAt  =  new System.DateTimeOffset(Csv_Row.SampleDate).ToUnixTimeSeconds();
                    newListing.DataSource   = Csv_Row.DataSource;

                    newListing.UpdateCount  = -1;

                    Listings[currentIndex+1] = newListing;
                    currentIndex++;
                }
            }            
            catch (Exception ex)
            {
                throw new Exception("Error while adding a record to the pricelistings", ex);
            }
        }

        /// <summary>
        /// adds a record to the pricelistings of this station
        /// </summary>
        /// <param name="CSV_String"></param>
        public void addListing(Listing listingRow)
        {
            try
            {
                ListingExtendMode       = true;

                Listings[currentIndex+1] = listingRow;
                currentIndex++;
            }            
            catch (Exception ex)
            {
                throw new Exception("Error while adding a record to the pricelistings", ex);
            }
        }

        public Boolean ListingExtendMode 
        {
            get
            {
                return m_ListingExtendMode; 
            }
            set
            {
                if(value != m_ListingExtendMode)
                {
                    if(value)
                    {
                        // extend first step and activate
                        currentIndex    = Listings.GetUpperBound(0);
                        var newListings = Listings;
                        Array.Resize(ref newListings, currentIndex + 100);
                        Listings        = newListings;
                    }
                    else
                    {
                        //deactivate
                        var newListings = Listings;
                        Array.Resize(ref newListings, currentIndex + 1);
                        Listings        = newListings;
                    }

                    m_ListingExtendMode = value;
                }
                else if(value && (currentIndex == Listings.GetUpperBound(0)))
                {
                    // extend next step
                    var newListings = Listings;
                    Array.Resize(ref newListings, currentIndex + 100);
                    Listings        = newListings;
                }
            }
        }
    }
}
