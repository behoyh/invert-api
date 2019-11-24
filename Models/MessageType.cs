using System;
namespace invert_api.Models
{
    public enum MessageType
    {
        Banner = 0, // Urgent sets color, overrides standard
        Popup = 1,  // Urgent overrides standard
        Acknowledgement = 2, // Urgent overrides standard
        Marketing = 3, // Urgent sets display order
        LoginNotice = 4 // Standard message displays non-blocking intermintent outage message, Urgent and not targeted blocks UI for maintenece, Urgent and targeted is reguired update, targeted is optional update

        // Other message types for other platforms/services as needed
    }
}
