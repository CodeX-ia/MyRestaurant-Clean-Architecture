﻿namespace MyRestaurant.Api.Models;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}