// See https://aka.ms/new-console-template for more information
using CodeDemo1;
using CodeDemo2;
using CodeDemo3;
using FluentBuilderExample;
using ChildBuilderExample;
using ProgressiveBuilderExample;

var myHouse = new CodeDemo1.HouseWithGarage()
{
  Color = "White",
  Area = 1000,
  NumberOfFloor = 2,
  NumberOfBeds = 4,
  GarageArea = 100,
  Location = "Left"
};

var myHouse2 = new CodeDemo1.HouseWithSwimmingPoolAndGarage()
{
  Color = "White",
  Area = 1000,
  NumberOfFloor = 2,
  NumberOfBeds = 4,
  GarageArea = 100,
  GargareLocation = "Left",
  SwimmingPoolArea = 2,
  SwimmingPoolLocation = "Right",
};

var myHouse3 = new CodeDemo2.House("White", 1000, 2, 4, new CodeDemo2.Garage(1, "Left"), new CodeDemo2.Garden(1, 2), null);
var myHouse4 = new CodeDemo2.House("White", 1000, 2, 4, new CodeDemo2.Garage(1, "Left"), new CodeDemo2.Garden(1, 2), null);
var myHouse5 = new CodeDemo2.House("White", 1000, 2, 4, new CodeDemo2.Garage(1, "Left"), new CodeDemo2.Garden(1, 2), new CodeDemo2.SwimmingPool("After", 2));

var myHouse6 = new CodeDemo3.HouseBuilder()
    .WithArea(200)
    .WithNumberOfBeds(2)
    .WithNumberOfFloor(2)
    .WithColor("White")
    .AddGarage()
        .WithArea(20)
        .WithLocation("Left Of House")
        .Build()
    .AddGarden()
        .WithNumberOfTree(40)
        .WithArea(20)
        .Build()
    .AddSwimmingPool()
        .WithLocation("Right")
        .Build()
    .Build();

Console.WriteLine(myHouse6.Garage?.Location);
Console.WriteLine(myHouse6.Garden?.NumberOfTree);
Console.WriteLine(myHouse6.SwimmingPool?.Location);

 Fluent
var blog = new FluentBuilderExample.BlogBuilder()
    .WithTitle("Title")
    .WithContent("Content")
    .WithCategories("Sport", "Fashion", "Game")
    .WithTags("Tag1", "Tag2", "Tag3")
    .WithAuthor("Author")
    .Build();

Console.WriteLine(blog.Content);

// Child
var blogChildBuilder = new ChildBuilderExample.BlogBuilder()
    .WithTitle("Title")
    .WithContent("Content")
    .WithAuthor("Author")
    .AddCategory()
        .WithName("Name")
        .WithDescription("Description")
        .Build()
    .Build();


var blogblogChildBuilder2 = new ChildBuilderExample.BlogBuilder()
    .WithTitle("Title")
    .WithContent("Content")
    .WithAuthor("Author")
    .AddCategory(cate =>
    {
      cate.WithName("Name");
      cate.WithDescription("Description");
    })
    .Build();

Console.WriteLine(blogChildBuilder.Category.Name);
Console.WriteLine(blogblogChildBuilder2.Category.Name);

var blogChildBuilder3 = new ChildBuilderExample.BlogBuilder()
    .WithTitle("Title")
    .WithContent("Content")
    .WithAuthor("Author")
    .AddCategory(cate =>
    {
      cate.WithName("Name");
      cate.WithDescription("Description");
      cate.AddCategoryChild(cateChild =>
      {
        cateChild.WithName("Name");
        cateChild.WithDescription("Description");
      });
    })
    .Build();

//// Progressive
var resume = new ProgressiveBuilderExample.ResumeBuilder()
    .WithTitle("Title")
    .WithDescription("Description")
    .WithAvatarUrl("AvatarUrl")
    .WithCandidateName("CandidateName")
    .AddEducation(edu =>
    {
      edu.WithName("Name");
      edu.WithDescription("Description");
      edu.WithGPA(3.7);
      edu.WithEducationAchivement("EducationAchivement");
    })
    .AddWork(work =>
    {
      work.WithTitle("Title");
      work.WithDescription("Description");
      work.WithCompany("Company");
      work.WithStartDate(DateTime.Now.AddDays(-90));
      work.WithEndDate(DateTime.Now);
    })
    .Build();

Console.WriteLine(resume.Education.EducationAchivement);
Console.WriteLine(resume.Work.Company);