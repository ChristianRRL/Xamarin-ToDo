using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo
{
	public partial class CreatePage : ContentPage
	{

		//		public List<ToDoItem> toDoItems;
		private CreatePageViewModel vm;
		private int updateID = 0;

		public CreatePage(int id)
		{
			vm = new CreatePageViewModel();
			BindingContext = vm;
//			toDoItems = new List<ToDoItem>();
			InitializeComponent();
			ToDoItem toDoItem = App.Database.GetToDo(id);
			ToDoEntry.Text = toDoItem.TaskName;
			Priority.Text = toDoItem.Priority;
			Date.Date = toDoItem.DueDate;
			Time.Time = toDoItem.DueDate.TimeOfDay;
			updateID = id;
		}

		public CreatePage()
		{
			vm = new CreatePageViewModel();
			BindingContext = vm;
			InitializeComponent();
		}

		// Event Handlers (OnSave, OnCancel, OnReview)
		public void OnSave(object o, EventArgs e)
		{
			vm.AddTask(
				ToDoEntry.Text,
				Priority.Text,
				Date.Date,
				Time.Time.Hours,
				Time.Time.Minutes,
				Time.Time.Seconds,
				updateID,
				false
			);

//			toDoItems.Add(
//				new ToDoItem(
//					ToDoEntry.Text,
//					Priority.Text,
//					SetDueDate(
//						Date.Date,
//						Time.Time.Hours,
//						Time.Time.Minutes,
//						Time.Time.Seconds
//					),
//					false
//				)
//			);
			Clear();
		}

//		private DateTime SetDueDate(DateTime date, int hour, int minute, int second)
//		{
//			DateTime retVal = new DateTime(
//				                  date.Year, 
//				                  date.Month, 
//				                  date.Day, 
//				                  hour, 
//				                  minute, 
//				                  second);
//
//			return retVal;
//		}

		private void Clear()
		{
			ToDoEntry.Text = Priority.Text = String.Empty;
			Date.Date = DateTime.Now;
			Time.Time = new TimeSpan(
				DateTime.Now.Hour,
				DateTime.Now.Minute,
				DateTime.Now.Second
			);
		}

		public void OnCancel(object o, EventArgs e)
		{
			
		}

		public void OnReview(object o, EventArgs e)
		{
//			var tempList = toDoItems;
			Clear();
//			Navigation.PushAsync(new ListTasksPage(public ListTasksPage(List<ToDoItem> items)));	// I think thats the parameter
			Navigation.PushAsync(new ListTasksPage());
		}
	}
}

