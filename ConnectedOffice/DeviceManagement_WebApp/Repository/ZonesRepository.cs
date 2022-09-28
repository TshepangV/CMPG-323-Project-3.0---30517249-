using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

       

        // GET: Zones
        public List<Zone>GetAll()
        {
            return _context.Zone.ToList();
        }

        // GET: Zones by ID
        public async Task<Zone> GetById(Guid? id)
        {

            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);

            return (zone);
            
        }

        // GET: Zones Create
        public Zone Create()
        {
            return ViewResult();
        }

        private Zone ViewResult()
        {
            throw new NotImplementedException();
        }

        // POST: Zones Create by zone
        public async Task<Zone> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private Zone RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        // GET: Zones Edit
        public async Task<Zone> Edit(Guid? id)
        {
           

            var zone = await _context.Zone.FindAsync(id);
           
            return (zone);
        }

        // POST: Zones Edit by id
        public async Task<Zone> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            
                _context.Update(zone);
                await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }

        // GET: Zones Delete
        public async Task<Zone> Delete(Guid? id)
        {
            

            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            

            return (zone);
        }

        // POST: ZonesDelete by zone
        public async Task<Zone> DeleteConfirmed(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
