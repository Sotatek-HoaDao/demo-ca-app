import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/pages/home/home.component';
import { MoviesComponent } from 'src/app/pages/movies/movies.component';
import { RatingComponent } from 'src/app/pages/rating/rating.component';
import { ProfileComponent } from 'src/app/pages/profile/profile.component';
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: 'movie',
    component: MoviesComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'rating',
    component: RatingComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
