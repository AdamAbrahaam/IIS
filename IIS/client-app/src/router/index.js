import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Tournaments from "../views/Tournaments.vue";
import Tournament from "../views/Tournament.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: Home
  },
  {
    path: "/tournaments",
    name: "tournaments",
    component: Tournaments
  },
  {
    path: "/tournament/:id",
    name: "tournament",
    component: Tournament,
    params: true
  },
  {
    path: "/about",
    name: "about",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue")
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
