<template>
    <div class="dialogs" v-if="show" @click="hideDialog">
        <div @click.stop class="dialogs__content">
            <slot></slot>
        </div>
    </div>
</template>
<script>
import toggleMixin from '@/mixins/toggleMixin'
export default {
    name:"my-dialogs",
    mixins:[toggleMixin],
}
</script>
<style>
.dialogs{
    top: 0;
    bottom: 0;
    right: 0;
    left: 0;
    background: rgba(0, 0, 0, 0.5);
    position: absolute;
    display: flex;
    z-index: 999;
}
.dialogs__content{
    padding: 30px 70px;
    border-radius: 12px;
    margin: auto;
    background: #fff;
}
</style>