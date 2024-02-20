﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop4.States
{
    internal class CreatedOrderState : IOrderState
    {
        private readonly IOrderState _context;
        public CreatedOrderState(IOrderState context)
        {
            this._context = context;
        }
        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
