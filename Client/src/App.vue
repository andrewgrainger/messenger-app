<template>
  <main class="app-container dark-theme-bg">
    <form v-if="addNewRoom" @submit.prevent="createRoom" class="dark-theme-bg form-container">
      <input v-model="addRoomUsername" type="text" placeholder="Add username" />
      <input v-model="addRoomName" type="text" placeholder="Add room name" />
      <button type="submit" :disabled="disableForm">
        Create Room
      </button>
      <button class="button-cancel" @click="addNewRoom = false">Cancel</button>
    </form>

    <vue-advanced-chat 
      height="calc(100vh - 20px)" 
      :current-user-id="currentUserId" 
      :rooms="rooms"
      :loading-rooms="roomsLoading" 
      :rooms-loaded="roomsLoaded" 
      @add-room="addNewRoom = true" 
      @fetch-more-rooms="fetchMoreRooms" 
      theme="dark" />
  </main>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { register, type Message, type Room } from 'vue-advanced-chat'
import { useRoomStore } from '@/stores/room'
import { storeToRefs } from 'pinia';

register()

const roomStore = useRoomStore();
const { rooms, roomsPage, roomsLoading, roomsLoaded, addNewRoom, disableForm, addRoomName, addRoomUsername } = storeToRefs(roomStore);
const currentUserId = ref<string>('1234');

onMounted(() => {
  roomStore.fetchUserRooms({ "username": "string", pageSize:16 });
})

const createRoom = () => {
  roomStore.createRoom({ userNames: [addRoomUsername.value, currentUserId.value], roomName: addRoomName.value })
}

const fetchMoreRooms = async () => {
  roomStore.fetchUserRooms({ "username": "string", pageIndex: ++roomsPage.value, pageSize:20})
}

</script>

<style scoped>

.app-container {
  padding: 20px 30px 30px;
}

.form-container {
  display: flex;
  gap: 10px;
}

.dark-theme-bg {
  background-color: #181a1b;
}

.light-theme-bg {
  background-color: white;
}
</style>