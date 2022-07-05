using CadastroClientes.Models;
using CadastroClientes.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroClientes.Util;
using CadastroClientes.Context;

namespace CadastroClientes.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(AppDbContext context)
        {
            _userRepository = new UserRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var users = await _userRepository.GetAll();
            var viewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                viewModels.Add(new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Mail = user.Mail,
                    Address = user.Address,
                    Password = user.Password,
                    Active = user.Active,
                    PhoneNumber = user.PhoneNumber,
                    Document = user.Document,
                    BirthDate = user.BirthDate,
                    Gender = user.Gender,
                });
            }

            return View(viewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            try
            {
                await _userRepository.Insert(new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Mail = user.Mail,
                    Address = user.Address,
                    Password = MD5Hash.CalculaHash(user.Password),
                    Active = user.Active,
                    PhoneNumber = user.PhoneNumber,
                    Document = user.Document,
                    BirthDate = user.BirthDate,
                    Gender = user.Gender,
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            //sss
            var model = await _userRepository.GetUserById(id);
            var user = new UserViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Mail = model.Mail,
                Address = model.Address,
                Password = model.Password,
                Active = model.Active,
                PhoneNumber = model.PhoneNumber,
                Document = model.Document,
                BirthDate = model.BirthDate,
                Gender = model.Gender
            };

            return View(user);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _userRepository.GetUserById(id);
            var user = new UserViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Mail = model.Mail,
                Address = model.Address,
                Password = model.Password,
                Active = model.Active,
                PhoneNumber = model.PhoneNumber,
                Document = model.Document,
                BirthDate = model.BirthDate,
                Gender = model.Gender
            };

            return View(user);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                await _userRepository.Delete(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
