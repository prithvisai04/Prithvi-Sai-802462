﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.Userservice.Context;
using MOD.Userservice.Models;

namespace MOD.Userservice.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly UserContext _context;
        public MentorRepository(UserContext context)
        {
            _context = context;
        }
        public void Add(Mentor item)
        {
            _context.Mentors.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Mentors.Find(id);
            _context.Mentors.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Mentor item)
        {
            _context.Entry(item).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Mentor> GetMentors()
        {
            return _context.Mentors.ToList();
        }

        public void ResetPassword(string email, string NewPass)
        {
            var resetPass = _context.Mentors.SingleOrDefault(i => i.Email == email);
            resetPass.Password = NewPass;
            _context.SaveChanges();
        }
    }
}
