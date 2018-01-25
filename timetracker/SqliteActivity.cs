﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using static TimeTracker.KimaiDatadase;

namespace TimeTracker
{
    [Activity(Label = "SqliteActivity", MainLauncher = false)]
    public class SqliteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SqlLayout);
            string dbPath = System.IO.Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "localkimaidata.db3");
            var db = new SQLiteConnection(dbPath);
            var customers = db.Table<Customer>();
            TextView Tv = FindViewById<TextView>(Resource.Id.TEXT_STATUS_ID);

            Tv.Text = "";
            Tv.Append("======= Customers ==========");
            Tv.Append(System.Environment.NewLine);
            foreach (var customer in customers)
            {
                Tv.Append (customer.ToString());
                Tv.Append(System.Environment.NewLine);
            }
            Tv.Append("=========================");
            Tv.Append(System.Environment.NewLine);

            Tv.Append("======= Projects ==========");
            Tv.Append(System.Environment.NewLine);
            var projects = db.Table<Project>();

            foreach (var project in projects)
            {
                Tv.Append(project.ToString());
                Tv.Append(System.Environment.NewLine);
            }
            Tv.Append("=========================");
            Tv.Append(System.Environment.NewLine);

            Tv.Append("======= Activities ==========");
            Tv.Append(System.Environment.NewLine);
            var activities = db.Table<ProjectActivity>();

            foreach (var activity in activities)
            {
                Tv.Append(activity.ToString());
                Tv.Append(System.Environment.NewLine);
            }
            Tv.Append("=========================");
            Tv.Append(System.Environment.NewLine);


            Button cancel_button = FindViewById<Button>(Resource.Id.btn_sqlcancel);
            cancel_button.Click += delegate
            {
                StartActivity(typeof(Settings));
            };
        }

    }
}
