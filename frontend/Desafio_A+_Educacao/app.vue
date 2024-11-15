<template>
      <NuxtLayout>
        <v-app>
          <v-navigation-drawer app permanent>
            <LayoutSidebar />
        </v-navigation-drawer>
          <NuxtPage />
          <v-app-bar app>
            <LayoutHeader />
        </v-app-bar>
        </v-app>
      </NuxtLayout>
</template>
