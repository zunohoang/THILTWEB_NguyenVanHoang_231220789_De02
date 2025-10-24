using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenVanHoang_231220789_De02.Models;

namespace NguyenVanHoang_231220789_De02.Controllers
{
    public class NvhCatalogsController : Controller
    {
        private readonly NvhDbContext _context;

        public NvhCatalogsController(NvhDbContext context)
        {
            _context = context;
        }

        // GET: NvhCatalogs
        public async Task<IActionResult> NvhIndex()
        {
            return View(await _context.NvhCatalogs.ToListAsync());
        }

        // GET: NvhCatalogs/Details/5
        public async Task<IActionResult> NvhDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvhCatalog = await _context.NvhCatalogs
                .FirstOrDefaultAsync(m => m.nvhId == id);
            if (nvhCatalog == null)
            {
                return NotFound();
            }

            return View(nvhCatalog);
        }

        // GET: NvhCatalogs/Create
        public IActionResult NVhCreate()
        {
            return View();
        }

        // POST: NvhCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> NvhCreate([Bind("nvhId,nvhCateName,nvhCatePrice,nvhCateQty,nvhPicture,nvhCateActive")] NvhCatalog nvhCatalog)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(nvhCatalog);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(nvhCatalog);
        //}

        // GET: NvhCatalogs/Edit/5
        public async Task<IActionResult> NvhEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvhCatalog = await _context.NvhCatalogs.FindAsync(id);
            if (nvhCatalog == null)
            {
                return NotFound();
            }
            return View(nvhCatalog);
        }

        // POST: NvhCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> NvhEdit(int id, [Bind("nvhId,nvhCateName,nvhCatePrice,nvhCateQty,nvhPicture,nvhCateActive")] NvhCatalog nvhCatalog)
        //{
        //    if (id != nvhCatalog.nvhId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(nvhCatalog);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NvhCatalogExists(nvhCatalog.nvhId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(NvhIndex));
        //    }
        //    return View(nvhCatalog);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvhEdit(int id, NvhCatalog nvhCatalog)
        {
            if (id != nvhCatalog.nvhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Nếu có upload ảnh mới
                    if (nvhCatalog.UploadImage != null)
                    {
                        var fileName = Path.GetFileName(nvhCatalog.UploadImage.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await nvhCatalog.UploadImage.CopyToAsync(stream);
                        }

                        // cập nhật tên file ảnh mới
                        nvhCatalog.nvhPicture = fileName;
                    }

                    _context.Update(nvhCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NvhCatalogExists(nvhCatalog.nvhId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NvhIndex));
            }
            return View(nvhCatalog);
        }


        // GET: NvhCatalogs/Delete/5
        public async Task<IActionResult> NvhDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvhCatalog = await _context.NvhCatalogs
                .FirstOrDefaultAsync(m => m.nvhId == id);
            if (nvhCatalog == null)
            {
                return NotFound();
            }

            return View(nvhCatalog);
        }

        // POST: NvhCatalogs/Delete/5
        // POST: NvhCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvhDeleteConfirmed(int id)
        {
            Console.WriteLine($"🗑 Delete gọi với id={id}");

            var nvhCatalog = await _context.NvhCatalogs.FindAsync(id);
            if (nvhCatalog != null)
            {
                Console.WriteLine($"✅ Xoá {nvhCatalog.nvhCateName}");
                _context.NvhCatalogs.Remove(nvhCatalog);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("⚠ Không tìm thấy sản phẩm để xoá");
            }

            return RedirectToAction(nameof(NvhIndex));
        }


        private bool NvhCatalogExists(int id)
        {
            return _context.NvhCatalogs.Any(e => e.nvhId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvhCreate(NvhCatalog nvhCatalog)
        {
            if (ModelState.IsValid)
            {
                if (nvhCatalog.UploadImage != null)
                {
                    var fileName = Path.GetFileName(nvhCatalog.UploadImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await nvhCatalog.UploadImage.CopyToAsync(stream);
                    }

                    // Lưu tên file vào DB
                    nvhCatalog.nvhPicture = fileName;
                }

                _context.Add(nvhCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvhIndex));
            }
            return View(nvhCatalog);
        }

    }
}
