﻿using Microsoft.AspNetCore.Mvc;
using Quizly.Entities;
using Quizly.Exceptions;
using Quizly.Services;

namespace Quizly.Controllers;

public class PlayerController(IPlayerService playerService) : Controller
{
    private readonly IPlayerService _playerService = playerService;

    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        var players = _playerService.GetAllPlayers();
        return View("Players", players);
    }

    public IActionResult AddPlayer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddPlayer(Player player)
    {
        try
        {
            _playerService.AddPlayer(player);
            return RedirectToAction();
        }
        catch (Exception ex)
        {
            return ex switch
            {
                EmptyInputException => RedirectToAction("Error", "Home", new { message = ex.Message }),
                EntityAlreadyExistsException => RedirectToAction("Error", "Home", new { message = ex.Message }),
                _ => RedirectToAction("Error", "Home", new { message = ex.Message })
            };
        }
    }

    [HttpPost]
    public IActionResult DeletePlayer(int id)
    {
        _playerService.DeletePlayer(id);
        return RedirectToAction("GetAllPlayers");
    }
}