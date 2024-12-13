using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Console_MainApp.Dialogs;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService, FileService>()
    .AddSingleton<IContactService, ContactService>()
    .AddSingleton<IMenuDialog, MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetService<IMenuDialog>();

menuDialog.Main();