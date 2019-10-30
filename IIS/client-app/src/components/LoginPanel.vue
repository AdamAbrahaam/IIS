<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.email"
              v-model="userInfo.email"
              :rules="[rules.email, rules.required]"
              label="E-mail"
              type="email"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.password"
              v-model="userInfo.password"
              :rules="[rules.required]"
              label="Password"
              type="password"
              required
            ></v-text-field>
          </v-col>
          <v-col
            cols="12"
            v-show="this.user.error"
            class="my-n7 red--text text-center"
          >
            {{ this.user.error }}
          </v-col>
        </v-row>
      </v-container>
    </v-card-text>
    <v-card-actions>
      <div class="flex-grow-1"></div>
      <v-btn color="blue darken-1" text @click.prevent="login()">Login</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "LoginPanel",
  props: ["closeModal"],
  data() {
    return {
      userInfo: {
        email: "",
        password: ""
      },
      user: "",
      rules: {
        email: v => (v || "").match(/@/) || "Please enter a valid email",
        required: v => !!v || "This field is required"
      }
    };
  },
  methods: {
    async login() {
      this.user = await this.$store.dispatch("user/login", this.userInfo);

      if (this.user.error) {
        this.userInfo.password = "";
      } else {
        this.closeModal();
      }
    }
  }
};
</script>
