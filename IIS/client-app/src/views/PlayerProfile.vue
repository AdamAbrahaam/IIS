<template>
  <div>
    <DefaultHeader>
      <div slot="title">{{ profile.fullName }}</div>
      <v-card>
        <v-list two-line>
          <div class="title">Information</div>

          <v-divider></v-divider>

          <v-list-item>
            <v-list-item-content>
              <v-list-item-subtitle class="pl-3">Name</v-list-item-subtitle>
              <v-list-item-title
                ><v-text-field
                  ref="profile.fullName"
                  v-model="profile.fullName"
                  class="mb-n7"
                  :value="profile.fullName"
                  :outlined="!isEditing"
                  :flat="isEditing"
                  :solo="isEditing"
                  :readonly="isEditing"
                ></v-text-field
              ></v-list-item-title>
            </v-list-item-content>
          </v-list-item>

          <v-divider></v-divider>

          <v-list-item>
            <v-list-item-content>
              <v-list-item-subtitle class="pl-3">E-mail</v-list-item-subtitle>
              <v-list-item-title
                ><v-text-field
                  ref="profile.email"
                  v-model="profile.email"
                  class="mb-n7"
                  :value="profile.email"
                  :outlined="!isEditing"
                  :flat="isEditing"
                  :solo="isEditing"
                  :readonly="isEditing"
                ></v-text-field
              ></v-list-item-title>
            </v-list-item-content>
          </v-list-item>

          <v-divider></v-divider>

          <v-list-item>
            <v-list-item-content>
              <v-list-item-subtitle class="pl-3">Team</v-list-item-subtitle>
              <v-list-item-title
                ><span v-if="profile.team"
                  ><v-text-field
                    ref="profile.team"
                    v-model="profile.team"
                    class="mb-n7"
                    :value="profile.team"
                    :outlined="!isEditing"
                    :flat="isEditing"
                    :solo="isEditing"
                    :readonly="isEditing"
                  ></v-text-field
                ></span>
                <span v-else>None</span></v-list-item-title
              >
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-card>
    </DefaultHeader>
  </div>
</template>

<script>
import { mapState } from "vuex";
import DefaultHeader from "@/views/DefaultHeader.vue";

export default {
  name: "PlayerProfile",
  props: ["userId"],
  components: {
    DefaultHeader
  },
  created() {
    this.$store.dispatch("user/getProfile", this.userId);
  },
  computed: {
    ...mapState({
      profile: state => state.user.profile,
      editingState: state => state.tournaments.editing
    }),
    isEditing() {
      return !this.editingState;
    }
  }
};
</script>

<style lang="scss" scoped></style>
