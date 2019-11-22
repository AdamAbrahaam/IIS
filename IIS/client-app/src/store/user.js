import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    users: [],
    currentUser: JSON.parse(localStorage.getItem("currentUser") || "{}"),
    profile: {},
    editing: false,
    userStats: {}
  },
  mutations: {
    SET_CURRENT_USER(state, user) {
      state.currentUser = user;
      localStorage.setItem("currentUser", JSON.stringify(state.currentUser));
    },
    SET_AFTER_TEAM_DELETE(state, user) {
      user.team = null;
      state.currentUser = user;
    },
    SET_USERS(state, users) {
      state.users = users;
    },
    LOGOUT_USER(state) {
      state.currentUser = {};
      localStorage.removeItem("currentUser");
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
      } catch (exp) {
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
    async getAll({ commit }) {
      let response = await Api()
        .get("/users")
        .catch(error => console.log(error));

      let users = response.data;

      commit("SET_USERS", users);
      return users;
    },
    async getStatsForUser({ commit }, userId) {
      try {
        let response = await Api().get(`/users/stats-for-user/${userId}`);

        let stats = response.data;

        commit("SET_USER_STATS", stats);
        return stats;
      } catch (exp) {
        return {
          error: "Registration failed! Please try again."
        };
      }
    },
    async updateProfile({ commit }, { profileId, updatedInfo }) {
      try {
        let response = await Api().put(`/users/${profileId}`, updatedInfo);
        let profile = response.data;

        commit("SET_PROFILE", profile);
        return profile;
      } catch (exp) {
        return {
          error: "ERROR! Unchanged credentials!"
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
