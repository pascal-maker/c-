using Ct.Ai.Models;
using Ct.Ai.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ct.Ai.Services
{
    public class SmartPhoneService
    {
        private readonly SmartPhoneRepository _repo; // Use Ct.Ai.Repositories.SmartPhoneRepository

        public SmartPhoneService(SmartPhoneRepository repo) // Correct type
        {
            _repo = repo;
        }

        public List<Smartphone> GetAll() => _repo.GetSmartphones();

        public List<Smartphone> Search(string keyword)
        {
            return _repo.GetSmartphones()
                .Where(s => s.Brand.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || s.Type.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void Add(Smartphone phone)
        {
            var all = _repo.GetSmartphones();
            phone.Id = all.Max(p => p.Id) + 1;
            _repo.AddSmartphone(phone);
        }
    }
}