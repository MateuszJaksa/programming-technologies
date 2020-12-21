﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="LibraryDatabase")]
	public partial class LinqToSqlDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCatalogs(Catalogs instance);
    partial void UpdateCatalogs(Catalogs instance);
    partial void DeleteCatalogs(Catalogs instance);
    partial void InsertLibraryEvents(LibraryEvents instance);
    partial void UpdateLibraryEvents(LibraryEvents instance);
    partial void DeleteLibraryEvents(LibraryEvents instance);
    partial void InsertStates(States instance);
    partial void UpdateStates(States instance);
    partial void DeleteStates(States instance);
    partial void InsertUsers(Users instance);
    partial void UpdateUsers(Users instance);
    partial void DeleteUsers(Users instance);
    #endregion
		
		public LinqToSqlDataContext() : 
				base(global::Data.Properties.Settings.Default.LibraryDatabaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqToSqlDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Catalogs> Catalogs
		{
			get
			{
				return this.GetTable<Catalogs>();
			}
		}
		
		public System.Data.Linq.Table<LibraryEvents> LibraryEvents
		{
			get
			{
				return this.GetTable<LibraryEvents>();
			}
		}
		
		public System.Data.Linq.Table<States> States
		{
			get
			{
				return this.GetTable<States>();
			}
		}
		
		public System.Data.Linq.Table<Users> Users
		{
			get
			{
				return this.GetTable<Users>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Catalogs")]
	public partial class Catalogs : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Title;
		
		private string _Author;
		
		private EntitySet<States> _States;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    #endregion
		
		public Catalogs()
		{
			this._States = new EntitySet<States>(new Action<States>(this.attach_States), new Action<States>(this.detach_States));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="NVarChar(50)")]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this.OnAuthorChanging(value);
					this.SendPropertyChanging();
					this._Author = value;
					this.SendPropertyChanged("Author");
					this.OnAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalogs_States", Storage="_States", ThisKey="ID", OtherKey="CatalogId")]
		public EntitySet<States> States
		{
			get
			{
				return this._States;
			}
			set
			{
				this._States.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_States(States entity)
		{
			this.SendPropertyChanging();
			entity.Catalogs = this;
		}
		
		private void detach_States(States entity)
		{
			this.SendPropertyChanging();
			entity.Catalogs = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LibraryEvents")]
	public partial class LibraryEvents : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<System.DateTime> _Time;
		
		private System.Nullable<int> _StateId;
		
		private System.Nullable<int> _UserId;
		
		private System.Nullable<bool> _isBorrowingEvent;
		
		private EntityRef<States> _States;
		
		private EntityRef<Users> _Users;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeChanged();
    partial void OnStateIdChanging(System.Nullable<int> value);
    partial void OnStateIdChanged();
    partial void OnUserIdChanging(System.Nullable<int> value);
    partial void OnUserIdChanged();
    partial void OnisBorrowingEventChanging(System.Nullable<bool> value);
    partial void OnisBorrowingEventChanged();
    #endregion
		
		public LibraryEvents()
		{
			this._States = default(EntityRef<States>);
			this._Users = default(EntityRef<Users>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Time", DbType="DateTime")]
		public System.Nullable<System.DateTime> Time
		{
			get
			{
				return this._Time;
			}
			set
			{
				if ((this._Time != value))
				{
					this.OnTimeChanging(value);
					this.SendPropertyChanging();
					this._Time = value;
					this.SendPropertyChanged("Time");
					this.OnTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateId", DbType="Int")]
		public System.Nullable<int> StateId
		{
			get
			{
				return this._StateId;
			}
			set
			{
				if ((this._StateId != value))
				{
					if (this._States.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnStateIdChanging(value);
					this.SendPropertyChanging();
					this._StateId = value;
					this.SendPropertyChanged("StateId");
					this.OnStateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int")]
		public System.Nullable<int> UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._Users.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isBorrowingEvent", DbType="Bit")]
		public System.Nullable<bool> isBorrowingEvent
		{
			get
			{
				return this._isBorrowingEvent;
			}
			set
			{
				if ((this._isBorrowingEvent != value))
				{
					this.OnisBorrowingEventChanging(value);
					this.SendPropertyChanging();
					this._isBorrowingEvent = value;
					this.SendPropertyChanged("isBorrowingEvent");
					this.OnisBorrowingEventChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="States_LibraryEvents", Storage="_States", ThisKey="StateId", OtherKey="ID", IsForeignKey=true)]
		public States States
		{
			get
			{
				return this._States.Entity;
			}
			set
			{
				States previousValue = this._States.Entity;
				if (((previousValue != value) 
							|| (this._States.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._States.Entity = null;
						previousValue.LibraryEvents.Remove(this);
					}
					this._States.Entity = value;
					if ((value != null))
					{
						value.LibraryEvents.Add(this);
						this._StateId = value.ID;
					}
					else
					{
						this._StateId = default(Nullable<int>);
					}
					this.SendPropertyChanged("States");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_LibraryEvents", Storage="_Users", ThisKey="UserId", OtherKey="ID", IsForeignKey=true)]
		public Users Users
		{
			get
			{
				return this._Users.Entity;
			}
			set
			{
				Users previousValue = this._Users.Entity;
				if (((previousValue != value) 
							|| (this._Users.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Users.Entity = null;
						previousValue.LibraryEvents.Remove(this);
					}
					this._Users.Entity = value;
					if ((value != null))
					{
						value.LibraryEvents.Add(this);
						this._UserId = value.ID;
					}
					else
					{
						this._UserId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Users");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.States")]
	public partial class States : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<bool> _IsBorrowed;
		
		private System.Nullable<int> _CatalogId;
		
		private EntitySet<LibraryEvents> _LibraryEvents;
		
		private EntityRef<Catalogs> _Catalogs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnIsBorrowedChanging(System.Nullable<bool> value);
    partial void OnIsBorrowedChanged();
    partial void OnCatalogIdChanging(System.Nullable<int> value);
    partial void OnCatalogIdChanged();
    #endregion
		
		public States()
		{
			this._LibraryEvents = new EntitySet<LibraryEvents>(new Action<LibraryEvents>(this.attach_LibraryEvents), new Action<LibraryEvents>(this.detach_LibraryEvents));
			this._Catalogs = default(EntityRef<Catalogs>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsBorrowed", DbType="Bit")]
		public System.Nullable<bool> IsBorrowed
		{
			get
			{
				return this._IsBorrowed;
			}
			set
			{
				if ((this._IsBorrowed != value))
				{
					this.OnIsBorrowedChanging(value);
					this.SendPropertyChanging();
					this._IsBorrowed = value;
					this.SendPropertyChanged("IsBorrowed");
					this.OnIsBorrowedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CatalogId", DbType="Int")]
		public System.Nullable<int> CatalogId
		{
			get
			{
				return this._CatalogId;
			}
			set
			{
				if ((this._CatalogId != value))
				{
					if (this._Catalogs.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCatalogIdChanging(value);
					this.SendPropertyChanging();
					this._CatalogId = value;
					this.SendPropertyChanged("CatalogId");
					this.OnCatalogIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="States_LibraryEvents", Storage="_LibraryEvents", ThisKey="ID", OtherKey="StateId")]
		public EntitySet<LibraryEvents> LibraryEvents
		{
			get
			{
				return this._LibraryEvents;
			}
			set
			{
				this._LibraryEvents.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalogs_States", Storage="_Catalogs", ThisKey="CatalogId", OtherKey="ID", IsForeignKey=true)]
		public Catalogs Catalogs
		{
			get
			{
				return this._Catalogs.Entity;
			}
			set
			{
				Catalogs previousValue = this._Catalogs.Entity;
				if (((previousValue != value) 
							|| (this._Catalogs.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Catalogs.Entity = null;
						previousValue.States.Remove(this);
					}
					this._Catalogs.Entity = value;
					if ((value != null))
					{
						value.States.Add(this);
						this._CatalogId = value.ID;
					}
					else
					{
						this._CatalogId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Catalogs");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LibraryEvents(LibraryEvents entity)
		{
			this.SendPropertyChanging();
			entity.States = this;
		}
		
		private void detach_LibraryEvents(LibraryEvents entity)
		{
			this.SendPropertyChanging();
			entity.States = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class Users : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private EntitySet<LibraryEvents> _LibraryEvents;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Users()
		{
			this._LibraryEvents = new EntitySet<LibraryEvents>(new Action<LibraryEvents>(this.attach_LibraryEvents), new Action<LibraryEvents>(this.detach_LibraryEvents));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Users_LibraryEvents", Storage="_LibraryEvents", ThisKey="ID", OtherKey="UserId")]
		public EntitySet<LibraryEvents> LibraryEvents
		{
			get
			{
				return this._LibraryEvents;
			}
			set
			{
				this._LibraryEvents.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LibraryEvents(LibraryEvents entity)
		{
			this.SendPropertyChanging();
			entity.Users = this;
		}
		
		private void detach_LibraryEvents(LibraryEvents entity)
		{
			this.SendPropertyChanging();
			entity.Users = null;
		}
	}
}
#pragma warning restore 1591