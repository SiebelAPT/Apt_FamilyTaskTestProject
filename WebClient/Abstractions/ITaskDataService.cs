﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Shared.Models;
using WebClient.Services;
using Domain.Commands;
using Domain.Queries;
using Domain.ViewModel;

namespace WebClient.Abstractions
{    
    public interface ITaskDataService
    {
        IEnumerable<TaskVm> EnumTasksToDo { get; }
        TaskVm SelectedTask { get; }

        event EventHandler TasksChanged;
        event EventHandler TaskSelected;
        event EventHandler SelectedTaskChanged;
        event EventHandler ShowAllTaskClicked;
        event EventHandler<string> UpdateTaskFailed;
        event EventHandler<string> CreateTaskFailed;
        event EventHandler<string> GetTasksFailed;

        void SelectTask(Guid id);
        void ToggleTask(Guid id);
        void AddTask(TaskVm model);
        Task CreateTask(TaskVm model);
        Task UpdateTask(TaskVm model);
        Task AssignTask(Guid id, Guid assignToMemberId, TaskVm model);
        Task CompleteTask(Guid id, bool isComplete, TaskVm model);
        Task CompleteMemberTask(Guid id, bool isComplete, Guid assignToMemberId, TaskVm model);
        Task GetTasks();
        TaskToDoModel[] PopulateLoadedTasks(List<TaskVm> loadedTasks, MemberVm selectedMember, IMemberDataService loadedMembers);
        void SelectNullTask();
    }
}