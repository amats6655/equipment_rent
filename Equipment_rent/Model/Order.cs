﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Equipment_rent.Model
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        public int UserId { get; set; }
        public int EquipmentId { get; set; }
        public int Amount { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturned { get; set; }

        public Guid WhoGive { get; set; }
        public Guid WhoTake { get; set; }

        [NotMapped] public Auth_user Give { get { return DataWorker.GetAuthUserById(WhoGive); } }
        [NotMapped] public Auth_user Take { get { return DataWorker.GetAuthUserById(WhoTake); } }


        [NotMapped] public string? BgColor { get; set; }
        [NotMapped]
        public User OrdersUser
        {
            get
            {
                return DataWorker.GetUserById(UserId);
            }
        }
        [NotMapped]
        public Equipment OrdersEquipment
        {
            get
            {
                return DataWorker.GetEquipmentById(EquipmentId);
            }
        }
        [NotMapped]
        public string FormattedDateIssue
        {
            get
            {
                return DateIssue.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
        }
        [NotMapped]
        public string FormattedDateReturn
        {
            get
            {
                return DateReturn.ToString("D", CultureInfo.CreateSpecificCulture("ru-RU"));
            }
        }

    }
}
