using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSportsClub.Data;
using MvcSportsClub.Models;
using MySportsClubLesson6.Models;
using MySportsClubLesson6.Services;

namespace MvcSportsClub.Controllers
{
    // todo lesson 4-16a - Apply authorisation without roles. 
    // Here: only allow access to any authenticated user
    [Authorize]
    public class WorkoutsController : Controller {
        private readonly IWorkoutRepository workoutRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IMailService mailService;

        // todo lesson 6-07 use constructor dependency injection for IMailService
        public WorkoutsController(
            IWorkoutRepository workoutRepository, 
            IMemberRepository memberRepository, 
            IMailService mailService) {
            this.workoutRepository = workoutRepository;
            this.memberRepository = memberRepository;
            this.mailService = mailService;
        }

        // GET: Workouts
        // todo lesson 4-16b: allow acces to non-authenticated users
        [AllowAnonymous]
        public async Task<IActionResult> Index() {
            var user = HttpContext.User;
            return View(await workoutRepository.FindAllAsync());
        }


        // GET: Workouts/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var workout = await workoutRepository.FindAsync(id.Value);
            if (workout == null) {
                return NotFound();
            }

            return View(workout);
        }

        // GET: Workouts/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Location,StartTime,EndTime")] Workout workout) {
            if (ModelState.IsValid) {
                await workoutRepository.InsertAsync(workout);
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }

        // GET: Workouts/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var workout = await workoutRepository.FindAsync(id.Value);
            if (workout == null) {
                return NotFound();
            }
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Location,StartTime,EndTime")] Workout workout) {
            if (id != workout.ID) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                await workoutRepository.UpdateAsync(workout);
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }

        // GET: Workouts/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            Workout workout = await workoutRepository.FindAsync(id.Value);
            if (workout == null) {
                return NotFound();
            }

            return View(workout);
        }


        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            Workout workout = await workoutRepository.FindAsync(id);
            await workoutRepository.DeleteAsync(workout);

            // todo lesson 6-08 notify members when a workout is cancelled (deleted)
            await notifyMembersDeletedWorkout(workout);
            return RedirectToAction(nameof(Index));
        }

        // todo lesson 6-09 use the MailService to send a mail to all members that the workout is cancelled
        private async Task notifyMembersDeletedWorkout(Workout workout) {

            //MailRequest mailRequest = new MailRequest() {
            //    ToEmail = "pjfmast@gmail.com",
            //    Subject = $"workout {workout.Title} cancelled",
            //    Body = $"Hi, the workout {workout.Title} at {workout.StartTime} has been cancelled."
            //};
            //await mailService.SendMailAsync(mailRequest);

            // notify al members of cancelled workout:
            var members = await memberRepository.FindAllAsync();

            foreach (var member in members) {
                MailRequest mailRequest = new MailRequest() {
                    ToEmail = member.Email,
                    Subject = $"workout {workout.Title} cancelled",
                    Body = $"Hi {member.Name}, the workout {workout.Title} at {workout.StartTime} has been cancelled."
                };
                await mailService.SendMailAsync(mailRequest);
            }

            

  
        }

        private async Task<bool> WorkoutExists(int id) {
            Workout workout = await workoutRepository.FindAsync(id);
            return workout != null;
        }
    }
}
