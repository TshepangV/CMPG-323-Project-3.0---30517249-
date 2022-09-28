using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        private List<Device> device;

        public object ViewData { get; private set; }

        // GET: Devices
        public List<Device> GetAll()
        {

            return _context.Device.Include(d => d.Category).Include(d => d.Zone).ToList();
        }

        // GET: Devices by id
        public async Task<Device> GetByid(Guid? id)
        {

            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            return (device);
        }

        // GET:Devices/Create
        public List<Device> Create()
        {

            var device = new SelectList(_context.Category, "CategoryId", "CategoryName");
            _ = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            return _context.Device.Include(d => d.Category).Include(d => d.Zone).ToList();
        }



        public async Task<Device> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            await _context.SaveChangesAsync();
            return RedirectToActionResult(nameof(Index));


        }

        private Device RedirectToActionResult(string v)
        {
            throw new NotImplementedException();
        }

        public Task<Device> Edit(Guid? id)
        {
            return Edit(id, ViewData);
        }

        // GET: Devices/Edit/5
        public async Task<Device> Edit(Guid? id, object viewData)
        {

            var device = await _context.Device.FindAsync(id);

            return (device);
        }

        public async Task<Device> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {

            _context.Update(device);
            await _context.SaveChangesAsync();

            return RedirectToActionResult(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<Device> Delete(Guid? id)
        {
           

            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            

            return (device);
        }

        // POST: Devices/Delete/5
        public async Task<Device> DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return (device);
        }

        
    }
}
