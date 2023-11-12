using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang.Models.CustomModels
{
    public class ResultBscScanResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public Result result { get; set; }
    }
    public class Result
    {
        public string blockNumber { get; set; }
        public string timeStamp { get; set; }
        public string blockMiner { get; set; }
        public string blockReward { get; set; }
        public List<object> uncles { get; set; }
        public string uncleInclusionReward { get; set; }
    }
}
