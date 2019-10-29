<template>
  <v-card>
    <v-card-text>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.firstName"
              v-model="userInfo.firstName"
              label="First name"
              type="text"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.lastName"
              v-model="userInfo.lastName"
              label="Last name"
              type="text"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.email"
              v-model="userInfo.email"
              label="E-mail"
              type="e-mail"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              ref="userInfo.password"
              v-model="userInfo.password"
              :append-icon="showPass ? 'eye-outline' : 'eye-off-outline'"
              :type="showPass ? 'text' : 'password'"
              label="Password"
              required
              @click:append="showPass = !showPass"
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
      <v-btn color="blue darken-1" text @click.prevent="register()"
        >Register</v-btn
      >
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "RegisterPanel",
  props: ["closeModal"],
  data() {
    return {
      userInfo: {
        firstName: "",
        lastName: "",
        email: "",
        password: ""
      },
      user: {},
      showPass: false
    };
  },
  methods: {
    async register() {
      this.user = await this.$store.dispatch("user/register", this.userInfo);

      if (this.user.error) {
        this.userInfo.password = "";
      } else {
        this.closeModal();
      }
    }
  }
};
</script>

<style lang="scss" scoped></style>
