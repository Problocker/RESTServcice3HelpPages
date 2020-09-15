using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestItemService.model
{
    public class FilterItem
    {
        //Instance Field
        private double _lowQuantity;
        private double _highQuantity;

        //Tom constructor
        public FilterItem()
        {
        }

        //Constructor
        public FilterItem(double lowQuantity, double highQuantity)
        {
            _lowQuantity = lowQuantity;
            _highQuantity = highQuantity;
        }

        //Properties
        public double LowQuantity
        {
            get => _lowQuantity;
            set => _lowQuantity = value;
        }

        public double HighQuantity
        {
            get => _highQuantity;
            set => _highQuantity = value;
        }
    }
}