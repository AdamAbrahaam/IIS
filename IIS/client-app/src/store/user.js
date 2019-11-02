import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    users: [],
    currentUser: {},
    profile: {},
    editing: false,
    userStats: {}
  },
  mutations: {
    SET_CURRENT_USER(state, user) {
      state.currentUser = user;
      window.localStorage.currentUser = JSON.stringify(user);
    },
    SET_USERS(state, users) {
      state.users = users;
    },
    LOGOUT_USER(state) {
      state.currentUser = {};
      window.localStorage.currentUser = JSON.stringify({});
    },
    SET_PROFILE(state, profile) {
      delete profile.password;
      state.profile = profile;
    },
    SET_EDIT(state, edit) {
      state.editing = edit;
    },
    SET_USER_STATS(state, stats) {
      state.userStats = stats;
    }
  },
  actions: {
    async register({ commit }, regInfo) {
      try {
        let response = await Api().post("/users/register", regInfo);
        let user = response.data;

        commit("SET_CURRENT_USER", user);
        return user;
      } catch {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    async login({ commit }, loginInfo) {
      try {
        let response = await Api().post("/users/login", loginInfo);
        let user = response.data;

        commit("SET_CURRENT_USER", user);
        return user;
      } catch (err) {
        return {
          error: "Email/password combination was incorrect.  Please try again."
        };
      }
    },
    async getProfile({ commit, dispatch }, userId) {
      try {
        let response = await Api()
          .get(`/users/${userId}`)
          .catch(error => console.log(error));

        let profile = response.data;

        commit("SET_PROFILE", profile);
        dispatch("getStatsForUser", userId);
        return profile;
      } catch (exp) {
        return {
          error: "Profile fetch failed! Please try again."
        };
      }
    },
    async getStatsForUser({ commit }, userId) {
      try {
        let response = await Api().get(`/users/stats-for-user/${userId}`);

        let stats = response.data;

        commit("SET_USER_STATS", stats);
        return stats;
      } catch (exp) {
        console.log(exp);
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    logout({ commit }) {
      commit("LOGOUT_USER");
    },
    async setEditing({ commit }, edit) {
      commit("SET_EDIT", edit);
    }
  }
};
