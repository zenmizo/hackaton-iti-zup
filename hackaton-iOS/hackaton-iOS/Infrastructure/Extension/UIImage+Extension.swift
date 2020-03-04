//
//  UIImage+Extension.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 04/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import UIKit

extension UIImageView {
    
    func pathImage(_ path: String) {
        guard let urlImage = URL(string: path) else { return }
        URLSession.shared.dataTask(with: urlImage) { (data, teste, ad) in
            if let dataImage = data {
                DispatchQueue.main.async() {
                    self.image = UIImage(data: dataImage)
                }
            }
        }.resume()
    }
}

