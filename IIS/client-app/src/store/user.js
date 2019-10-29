import Api from "../services/api";

export default {
  namespaced: true,
  state: {
    users: [],
    currentUser: {}
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
    logout({ commit }) {
      commit("LOGOUT_USER");
    }
  }
};
