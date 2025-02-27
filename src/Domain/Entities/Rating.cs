﻿using demo_ca_app.Domain.Common;
using demo_ca_app.Domain.Enums;
using demo_ca_app.Domain.Events;
using System;
using System.Collections.Generic;

namespace demo_ca_app.Domain.Entities
{
    public class Rating : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        //public TodoList List { get; set; }

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Comment { get; set; }
        public int RatingPoint { get; set; }
        public string UserMail { get; set; }

        //public PriorityLevel Priority { get; set; }

        //public DateTime? Reminder { get; set; }

        //private bool _done;
        //public bool Done
        //{
        //    get => _done;
        //    set
        //    {
        //        if (value == true && _done == false)
        //        {
        //            DomainEvents.Add(new TodoItemCompletedEvent(this));
        //        }

        //        _done = value;
        //    }
        //}

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
