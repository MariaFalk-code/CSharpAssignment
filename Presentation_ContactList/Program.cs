
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ContactList_ConsoleApp.Dialogs;


var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IFileService, FileService>();
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();
menuDialogs.RunMainMenu();
