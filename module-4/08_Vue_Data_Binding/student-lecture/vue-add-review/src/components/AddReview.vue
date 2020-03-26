<template>
  <div class="container">
    <!-- TODO: Show the book title in the heading -->
    <h1>
      Add New Review for
      <em></em>
    </h1>
    <div class="row">
      <div class="col-7">
        <form v-on:submit.prevent="saveReview">
          <input type="button" v-on:click="reset" class="btn btn-sm btn-danger" value="Clear form" />
          <div class="form-group">
            <label for="title">Title</label>
            <!-- TODO: Bind to title -->
            <input type="text" class="form-control" id="title" placeholder="Enter title" />
          </div>
          <div class="form-group">
            <label for="reviewer">Reviewer</label>
            <!-- TODO: Bind to reviewer -->
            <input
              type="text"
              class="form-control"
              id="reviewer"
              placeholder="Enter reviewer's name"
            />
          </div>
          <div class="form-group">
            <label for="rating">Rating</label>
            <!-- TODO: Bind to rating -->
            <!-- TODO: Bind the class to excellent or poor depending on rating -->
            <select class="form-control" id="rating">
              <!-- TODO: Generate 5 option tags, 1-5 -->
            </select>
          </div>
          <div class="form-group">
            <label for="review">Review</label>
            <!-- TODO: Bind to review -->
            <textarea class="form-control" id="review" rows="3"></textarea>
          </div>
          <button type="submit" class="btn btn-primary">Save Review</button>
        </form>
      </div>
      <div class="col-5">
        <h2>Submission</h2>
        <hr />
        <!-- TODO: Display all the fields here: title, reviewer, rating, review -- using one-way binding -->
        <p>Title:</p>
        <p>Reviewer:</p>
        <p>Rating:</p>
        <p>Review:</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    // TODO: Add a props for bookTitle to be passed in
  },
  data() {
    return {
      // TODO: In our data, define a review object to store our data and bind to the form fields
    };
  },
  methods: {
    // TODO: saveReview() should stringify the review and then send it to the server for processing (alert will suffice for now);
    // Also, call this.reset() when done to clear the form.
    saveReview(){},

    // TODO: reset() should clear the review, and therefore the form.
    reset(){}
  }
};
</script>

<style>
h1 {
  margin-top: 20px;
}
.excellent {
  background-color: greenyellow;
}
.poor {
  background-color: indianred;
}
</style>
