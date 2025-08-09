using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DTOLayer.AboutDtos
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string Vision { get; set; }
        public string Mission { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public int StartYear { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string item1 { get; set; }
        public string item2 { get; set; }
        public string item3 { get; set; }
        public string item4 { get; set; }
        public string NameSurname { get; set; }
        public string JobTitle { get; set; }
        public string ProfilePic { get; set; }
    }
}
