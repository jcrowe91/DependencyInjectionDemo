using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class BusinessLogic : IBusinessLogic
    {
        //class level variables
        ILogger _logger;
        IDataAccess _dataAccess;

        //constructor passing in logger and data assess needed for ProcessData method
        //allows the dependencies to pass up the chain
        public BusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public void ProcessData()
        {
            //removing instantiations and changing names below
            //Logger logger = new Logger();
            //DataAccess dataAccess = new DataAccess();

            _logger.Log("Starting the processing of data.");
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.Log("Finished processing of the data.");
        }
    }
}
