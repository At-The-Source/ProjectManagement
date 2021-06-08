using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProjectManagement.App.Contracts;
using ProjectManagement.App.Authentication;


namespace ProjectManagement.App.Pages
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected async Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }
        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }
        protected async void LogOut()
        {
            await AuthenticationService.LogOut();
        }
    }
}
