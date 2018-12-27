using System.Collections.Generic;

namespace PosnetParser.Models
{
    public class ParserMappingBuilder
    {
        private string _numberName;
        private string _descriptionName;
        private string _barcodeName;
        private string _minWarehouseName;
        private string _typeName;
        private string _vatName;
        private string _priceName;
        private string _packageNumberName;
        private string _unitOfMeasureNumberName;
        private string _amountFormatName;
        private string _isFixedName;
        private string _discountNumberName;
        private string _groupName;
        private string _discountCoatingName;
        private string _amountName;
        private string _linkedPluName;
        private string _notebookName;

        public ParserMappingBuilder SetNumberFieldName(string numberFieldName)
        {
            _numberName = numberFieldName;
            return this;
        }

        public ParserMappingBuilder SetDescriptionFieldName(string descriptionFieldName)
        {
            _descriptionName = descriptionFieldName;
            return this;
        }

        public ParserMappingBuilder SetBarcodeFieldName(string barcodeFieldName)
        {
            _barcodeName = barcodeFieldName;
            return this;
        }

        public ParserMappingBuilder SetMinWarehouseFieldName(string minWareHouseFieldName)
        { 
            _minWarehouseName = minWareHouseFieldName;
            return this;
        }

        public ParserMappingBuilder SetTypeFieldName(string typeFieldName)
        {
            _typeName = typeFieldName;
            return this;
        }


        public ParserMappingBuilder SetVatFieldName(string vatFieldName)
        {
            _vatName = vatFieldName;
            return this;
        }

        public ParserMappingBuilder SetPriceFieldName(string priceFieldName)
        {
            _priceName = priceFieldName;
            return this;
        }

        public ParserMappingBuilder SetPackageNumberFieldName(string packageNumberFieldName)
        {
            _packageNumberName = packageNumberFieldName;
            return this;
        }

        public ParserMappingBuilder SetUnitOfMeasureNumberFieldName(string unitOfMeasureNumberFieldName)
        {
            _unitOfMeasureNumberName = unitOfMeasureNumberFieldName;
            return this;
        }

        public ParserMappingBuilder SetAmountFormatFieldName(string amountFormatFieldName)
        {
            _amountFormatName = amountFormatFieldName;
            return this;
        }

        public ParserMappingBuilder SetIsFixedFieldName(string isFixedFieldName)
        {
            _isFixedName = isFixedFieldName;
            return this;
        }

        public ParserMappingBuilder SetDiscountNumberFieldName(string discountNumberFieldName)
        {
            _discountNumberName = discountNumberFieldName;
            return this;
        }

        public ParserMappingBuilder SetGroupNameFieldName(string groupNameFieldName)
        {
            _groupName = groupNameFieldName;
            return this;
        }

        public ParserMappingBuilder SetDiscountCoatingFieldName(string discountCoatingFieldName)
        {
            _discountCoatingName = discountCoatingFieldName;
            return this;
        }

        public ParserMappingBuilder SetAmountFieldName(string amountFieldName)
        {
            _amountName = amountFieldName;
            return this;
        }

        public ParserMappingBuilder SetLinkedPluFieldName(string linkedPluFieldName)
        {
            _linkedPluName = linkedPluFieldName;
            return this;
        }

        public ParserMappingBuilder SetNotebookFieldName(string notebookFieldName)
        {
            _notebookName = notebookFieldName;
            return this;
        }
    }
}
