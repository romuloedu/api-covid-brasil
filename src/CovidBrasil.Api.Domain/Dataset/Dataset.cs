using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CovidBrasil.Api.Domain.Common;

namespace CovidBrasil.Api.Domain.Dataset
{
    public class Dataset : BaseEntity
    {
        private List<Register> _registers;
        
        public String SourceName { get; private set; }

        public DateTime ReleasedDate { get; private set; }

        public DateTime UpdatedAt { get; private set; } = DateTime.Now;

        public ReadOnlyCollection<Register> Registers { 
            get { return _registers.AsReadOnly(); }
        }

        public Dataset(string sourceName, DateTime releasedDate)
        {
            SourceName = sourceName;
            ReleasedDate = releasedDate;
            _registers = new List<Register>();
        }

        public void AddRegister(Register register)
        {
            _registers.Add(register);
        }
    }
}
