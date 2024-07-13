import { combineReducers } from "redux";
import bookingReducer from "./bookingReducer";
import detailPostReducer from "./detailPostReducer";
import homeReducer from "./homeReducer";
import movieDetailReducer from "./movieDetailReducer";
import postListReducer from "./postListReducer";
import theaterReducer from "./theaterReducer";

export const allReducers = combineReducers({
  booking: bookingReducer,
  detailPost: detailPostReducer,
  home: homeReducer,
  movieDetail: movieDetailReducer,
  postList: postListReducer,
  theater: theaterReducer,
});
