using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class FullData 
    {
        public long id { get; set; }
        public string address { get; set; }
        public string level { get; set; }          //уровень до которого распознали: house, street, city, subregion - мун район, region - область
        public string country { get; set; }        //страна. есть не везде
        public string region { get; set; }         //субьект
        public string city { get; set; }           //город
        public string settlement { get; set; }     //поселение
        public string districtType { get; set; }   //тип муниципального образования Район / Поселение
        public string districtName { get; set; }   //название района / поселения
        public string streetSocr { get; set; }         //название улицы
        public string streetName { get; set; }         //название улицы
        public string houseNumber { get; set; }    //номер дома с литером: 12, 12А
        public string houseStructure { get; set; } //строение 12 стр2
        public string houseBody { get; set; }      //корпус 12 стр2 корп.1
        public string flat { get; set; }           //квартира
        public string office { get; set; }         //офис / помещение
    }
}
