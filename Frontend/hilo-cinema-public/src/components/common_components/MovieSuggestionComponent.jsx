import React from 'react';
import PropTypes from 'prop-types';
import MovieCardItem from './comom_item/MovieCardItem';
import { ExpandMore } from '@mui/icons-material';
import TitleItem from './comom_item/TitleItem';

const MovieSuggestionComponent = props => {
  return (
    <div className="hidden screen1200:block lg:col-span-2 w-full overflow-hidden">
      <TitleItem title='PHIM ĐANG CHIẾU' />
      <div className="movie__content">
        <ul className="flex flex-col justify-between">
          <MovieCardItem widthCard="400px" heightCard="250px" title="Kẻ Trộm Mặt Trăng 4" imageUrl="https://cdn.galaxycine.vn/media/2024/6/19/dm-4-750_1718771858571.jpg" />
          <MovieCardItem widthCard="400px" heightCard="250px" title="Những Mảnh Ghép Cảm Xúc 2" imageUrl="https://cdn.galaxycine.vn/media/2024/5/6/inside-out-2-1_1714970465678.jpg" />
        </ul>
        <div className="text-end">
          <a type="button" className="text-[#f26b38] hover:text-white w-40 border border-[#fb9440] hover:bg-[#fb9440] transition-all duration-300 focus:ring-1 focus:outline-none focus:ring-[#fb9440] rounded text-sm px-5 py-2.5 text-center inline-flex items-center dark:hover:bg-[#fb9440] dark:focus:ring-[#fb9440] mr-2 mb-2 justify-center" href="/phim-dang-chieu/">
            Xem thêm
            <ExpandMore />
          </a>
        </div>
      </div>
    </div>
  );
};

MovieSuggestionComponent.propTypes = {

};

export default MovieSuggestionComponent;