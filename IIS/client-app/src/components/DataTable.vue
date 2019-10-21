<template>
  <v-card
    flat
    height="100vh"
    color="rgba(0,0,0,0)"
    class="d-flex flex-column justify-center"
  >
    <div
      class="white--text display-2 pb-2 mt-n12 d-flex justify-center text-no-wrap"
    >
      Upcoming tournaments
    </div>
    <v-container>
      <v-data-table
        :headers="headers"
        :items="desserts"
        :sort-desc="[false, true]"
        multi-sort
        :mobile-breakpoint="0"
        hide-default-footer
        class="elevation-5 tournamentTable"
      ></v-data-table>
    </v-container>
  </v-card>
</template>

<script>
export default {
  name: 'DataTable',
  data() {
    return {
      headers: [
        {
          text: 'Name',
          align: 'left',
          sortable: false,
          value: 'name'
        },
        { text: 'Date', value: 'calories' },
        { text: 'Location', value: 'fat' },
        { text: 'Type', value: 'carbs' },
        { text: 'Entry', value: 'protein' },
        { text: 'Prize', value: 'iron' }
      ],
      desserts: [
        {
          name: 'Name1',
          calories: 200,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: '1%'
        },
        {
          name: 'Name2',
          calories: 200,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: '1%'
        },
        {
          name: 'Name3',
          calories: 200,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: '1%'
        },
        {
          name: 'Name4',
          calories: 200,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: '1%'
        },
        {
          name: 'Name5',
          calories: 200,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: '1%'
        }
      ]
    }
  }
}
</script>
