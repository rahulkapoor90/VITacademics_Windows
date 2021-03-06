﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace VITacademics.Managers
{
    /// <summary>
    /// A contract required to be implemented by every page to take part in the page management process.
    /// </summary>
    /// <remarks>
    ///  Note: The behaviour of these methods are not affected whether the page requested for caching or not.
    /// </remarks>
    public interface IManageable
    {
        /// <summary>
        /// This method should return any page specific state that is required to be stored.
        /// </summary>
        /// <remarks>
        /// This method is called by the PageManager on navigating away to another page (Not on going back).
        /// </remarks>
        /// <returns></returns>
        Dictionary<string, object> SaveState();
        /// <summary>
        /// This method is called by the PageManager when this page becomes the current page.
        /// </summary>
        /// <param name="lastState">
        /// The page state when it was last navigated to (as provided by the page).
        /// </param>
        /// <remarks>
        /// This method is not invoked if the there is no saved page state.
        /// </remarks>
        void LoadState(Dictionary<string, object> lastState);
    }


 #if WINDOWS_PHONE_APP
    /// <summary>
    /// Provides the contract for a page to allow or prevent app exit by pressing the back button.
    /// </summary>
    public interface IAppReturnControllable
    {
        /// <summary>
        /// This method is called when the user presses the back button to navigate out of the app. Return false to cancel this behaviour.
        /// </summary>
        Task<bool> AllowAppExit();
    }
#endif

    /// <summary>
    /// Types of navigation available when navigating to a page.
    /// </summary>
    public enum NavigationType
    {
        /// <summary>
        /// Simple navigates to the requested page and stores the last page's session.
        /// </summary>
        Default,
        /// <summary>
        /// Navigates to the requested page and resets all history and saved state. Use this mode even for a first time navigation.
        /// </summary>
        FreshStart
    }

}
