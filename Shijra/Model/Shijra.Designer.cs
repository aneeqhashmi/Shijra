﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("shijraModel", "FK_persondetails", "persons", System.Data.Entity.Core.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shijra.Model.Person), "persondetails", System.Data.Entity.Core.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(Shijra.Model.PersonDetail), true)]
[assembly: EdmRelationshipAttribute("shijraModel", "FK_persons", "persons", System.Data.Entity.Core.Metadata.Edm.RelationshipMultiplicity.One, typeof(Shijra.Model.Person), "persons1", System.Data.Entity.Core.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Shijra.Model.Person), true)]

#endregion

namespace Shijra.Model
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class shijraEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new shijraEntities object using the connection string found in the 'shijraEntities' section of the application configuration file.
        /// </summary>
        public shijraEntities() : base("name=shijraEntities", "shijraEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new shijraEntities object.
        /// </summary>
        public shijraEntities(string connectionString) : base(connectionString, "shijraEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new shijraEntities object.
        /// </summary>
        public shijraEntities(EntityConnection connection) : base(connection, "shijraEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PersonDetail> PersonDetails
        {
            get
            {
                if ((_PersonDetails == null))
                {
                    _PersonDetails = base.CreateObjectSet<PersonDetail>("PersonDetails");
                }
                return _PersonDetails;
            }
        }
        private ObjectSet<PersonDetail> _PersonDetails;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Person> Persons
        {
            get
            {
                if ((_Persons == null))
                {
                    _Persons = base.CreateObjectSet<Person>("Persons");
                }
                return _Persons;
            }
        }
        private ObjectSet<Person> _Persons;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PersonDetails EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPersonDetails(PersonDetail personDetail)
        {
            base.AddObject("PersonDetails", personDetail);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Persons EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPersons(Person person)
        {
            base.AddObject("Persons", person);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shijraModel", Name="Person")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Person : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Person object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="fatherId">Initial value of the FatherId property.</param>
        public static Person CreatePerson(global::System.Int64 id, global::System.String firstName, global::System.Int64 fatherId)
        {
            Person person = new Person();
            person.Id = id;
            person.FirstName = firstName;
            person.FatherId = fatherId;
            return person;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int64 _Id;
        partial void OnIdChanging(global::System.Int64 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                OnMiddleNameChanging(value);
                ReportPropertyChanging("MiddleName");
                _MiddleName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MiddleName");
                OnMiddleNameChanged();
            }
        }
        private global::System.String _MiddleName;
        partial void OnMiddleNameChanging(global::System.String value);
        partial void OnMiddleNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 FatherId
        {
            get
            {
                return _FatherId;
            }
            set
            {
                OnFatherIdChanging(value);
                ReportPropertyChanging("FatherId");
                _FatherId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FatherId");
                OnFatherIdChanged();
            }
        }
        private global::System.Int64 _FatherId;
        partial void OnFatherIdChanging(global::System.Int64 value);
        partial void OnFatherIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String UrduName
        {
            get
            {
                return _UrduName;
            }
            set
            {
                OnUrduNameChanging(value);
                ReportPropertyChanging("UrduName");
                _UrduName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("UrduName");
                OnUrduNameChanged();
            }
        }
        private global::System.String _UrduName;
        partial void OnUrduNameChanging(global::System.String value);
        partial void OnUrduNameChanged();
    
        /// <summary>
        /// true for male, false for female
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                OnGenderChanging(value);
                ReportPropertyChanging("Gender");
                _Gender = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Gender");
                OnGenderChanged();
            }
        }
        private global::System.Boolean _Gender = true;
        partial void OnGenderChanging(global::System.Boolean value);
        partial void OnGenderChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shijraModel", "FK_persondetails", "persondetails")]
        public PersonDetail Persondetail
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PersonDetail>("shijraModel.FK_persondetails", "persondetails").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PersonDetail>("shijraModel.FK_persondetails", "persondetails").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<PersonDetail> PersondetailReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PersonDetail>("shijraModel.FK_persondetails", "persondetails");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<PersonDetail>("shijraModel.FK_persondetails", "persondetails", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shijraModel", "FK_persons", "persons1")]
        public EntityCollection<Person> Childs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Person>("shijraModel.FK_persons", "persons1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Person>("shijraModel.FK_persons", "persons1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shijraModel", "FK_persons", "persons")]
        public Person Father
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persons", "persons").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persons", "persons").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Person> FatherReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persons", "persons");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Person>("shijraModel.FK_persons", "persons", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="shijraModel", Name="PersonDetail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PersonDetail : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PersonDetail object.
        /// </summary>
        /// <param name="personId">Initial value of the PersonId property.</param>
        public static PersonDetail CreatePersonDetail(global::System.Int64 personId)
        {
            PersonDetail personDetail = new PersonDetail();
            personDetail.PersonId = personId;
            return personDetail;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 PersonId
        {
            get
            {
                return _PersonId;
            }
            set
            {
                if (_PersonId != value)
                {
                    OnPersonIdChanging(value);
                    ReportPropertyChanging("PersonId");
                    _PersonId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PersonId");
                    OnPersonIdChanged();
                }
            }
        }
        private global::System.Int64 _PersonId;
        partial void OnPersonIdChanging(global::System.Int64 value);
        partial void OnPersonIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Education
        {
            get
            {
                return _Education;
            }
            set
            {
                OnEducationChanging(value);
                ReportPropertyChanging("Education");
                _Education = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Education");
                OnEducationChanged();
            }
        }
        private global::System.String _Education;
        partial void OnEducationChanging(global::System.String value);
        partial void OnEducationChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Occupation
        {
            get
            {
                return _Occupation;
            }
            set
            {
                OnOccupationChanging(value);
                ReportPropertyChanging("Occupation");
                _Occupation = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Occupation");
                OnOccupationChanged();
            }
        }
        private global::System.String _Occupation;
        partial void OnOccupationChanging(global::System.String value);
        partial void OnOccupationChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("shijraModel", "FK_persondetails", "persons")]
        public Person person
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persondetails", "persons").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persondetails", "persons").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Person> personReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("shijraModel.FK_persondetails", "persons");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Person>("shijraModel.FK_persondetails", "persons", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
