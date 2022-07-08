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
using CadastroClientes.ViewModels;

namespace CadastroClientes.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        public UserController(AppDbContext context)
        {
            _userRepository = new UserRepository(context);
        }


        [Route("")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/Create")]
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("/Create")]
        [HttpPost]
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

        [Route("/Update")]
        [HttpGet]
        public async Task<ActionResult> Update(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception();
                }

                var model = await _userRepository.GetUserById((int)id);
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
            catch (Exception)
            {
                return View();
            }
      
        }

        [Route("/Update")]
        [HttpPost]
        public async Task<ActionResult> Update(UserViewModel user)
        {
            try
            {
                var model = new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Mail = user.Mail,
                    Address = user.Address,
                    Active = user.Active,
                    PhoneNumber = user.PhoneNumber,
                    Document = user.Document,
                    BirthDate = user.BirthDate,
                    Gender = user.Gender,
                    Password = await _userRepository.GetUserPasswordById(user.Id)
                };

                await _userRepository.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [Route("/Delete")]
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var model = await _userRepository.GetUserById((int)id);
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

        [Route("/Delete")]
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userRepository.Delete(await _userRepository.GetUserById((int)id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
