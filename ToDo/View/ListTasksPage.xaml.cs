﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo
{
	public partial class ListTasksPage : ContentPage
	{
//		public List<ToDoItem> ToDoItems { get; set; }


//		public ListTasksPage(List<ToDoItem> items)
		public ListTasksPage()
		{
//			ToDoItems = items;
			BindingContext = this;
			InitializeComponent();
		}

		public void OnSelected(object o, ItemTappedEventArgs e)
		{
			var toDoItem = e.Item as ToDoItem;
			DisplayAlert("Chosen!", toDoItem.TaskName +
			"was selected!", "OK");
		}

		protected override void OnAppearing() {
			base.OnAppearing();
			ToDoList.ItemsSource = App.Database.GetToDos();
		}
	}
}

