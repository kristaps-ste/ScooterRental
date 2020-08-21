﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ScooterRental.Exceptions;

namespace ScooterRental
{
    public class ScooterService : IScooterService
    {
        private IList<Scooter> ScooterList { get; set; }

        public ScooterService()
        {
            ScooterList=new List<Scooter>();
        }

        public ScooterService(IList<Scooter> scooterList)
        {
            ScooterList = scooterList;
        }
        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (IsScooterExistInList(id))
            {
                throw new DuplicateScooterIdException(id);
            }
            ScooterList.Add(new Scooter(id,pricePerMinute));
        }

        public void RemoveScooter(string id)
        {
            if (!IsScooterExistInList(id))
            {
                throw new InvalidScooterIdException(id);
            }
            ScooterList = ScooterList.Where(it => it.Id != id).ToList();
        }

        public IList<Scooter> GetScooters()
        {
            return ScooterList.Where(it=>it.IsRented==false).ToList();
        }

        public IList<Scooter> GetScootersInUse()
        {
            return ScooterList.Where(it=>it.IsRented).ToList();
        }
        public Scooter GetScooterById(string scooterId)
        {
            if (!IsScooterExistInList(scooterId))
            {
                throw new InvalidScooterIdException(scooterId);
            }

            return ScooterList.First(it => it.Id == scooterId);
        }
        private bool IsScooterExistInList(string id)
        {
            return ScooterList.Any(it => it.Id == id);
        }
    }
}
